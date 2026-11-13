
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Files;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProjectFiles
{
    public class SaveProjectFileCommandHandler :
        IRequestHandler<SaveProjectFileCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFileClient _fileClient;

        public SaveProjectFileCommandHandler(
            ApplicationDbContext dbContext,
            IFileClient fileClient)
        {
            _dbContext = dbContext;
            _fileClient = fileClient;
        }

        public async Task<OperationResult<int>> Handle(
            SaveProjectFileCommand request,
            CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var projectTask = await _dbContext.ProjectTasks
                .FirstOrDefaultAsync(
                    item => item.Id == request.ProjectTaskId,
                    cancellationToken);

            if (projectTask == null)
            {
                result.AddError("Ülesannet ei leitud.");
                return result;
            }

            var originalFileName = Path.GetFileName(request.FileName);
            var storedFileName = Guid.NewGuid() +
                Path.GetExtension(originalFileName);

            var fileStore = Path.Combine(
                FileStore.Photos,
                projectTask.Id.ToString()
            );

            await _fileClient.Save(
                storedFileName,
                fileStore,
                request.InputStream);

            var entity = new ProjectFile
            {
                FileName = originalFileName,
                FilePath = Path.Combine(
                    FileStore.Photos,
                    projectTask.Id.ToString(),
                    storedFileName),
                UploadTime = DateTime.UtcNow
            };

            projectTask.Files.Add(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            result.Value = entity.Id;

            return result;
        }
    }
}
