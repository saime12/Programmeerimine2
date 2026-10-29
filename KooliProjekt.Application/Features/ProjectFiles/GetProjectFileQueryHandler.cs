using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProjectFiles
{
    public class GetProjectFileQueryHandler : IRequestHandler<GetProjectFileQuery, OperationResult<ProjectFileDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetProjectFileQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<ProjectFileDto>> Handle(GetProjectFileQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<ProjectFileDto>();
            response.Value = await _dbContext.ProjectFiles
                .AsNoTracking()
                .Where(item => item.Id == request.Id)
                .Select(item => new ProjectFileDto
                {
                    Id = item.Id,
                    FileName = item.FileName, FilePath = item.FilePath, UploadTime = item.UploadTime
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
