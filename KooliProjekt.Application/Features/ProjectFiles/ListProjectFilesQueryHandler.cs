using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProjectFiles
{
    internal class ListProjectFilesQueryHandler : IRequestHandler<ListProjectFilesQuery, OperationResult<PagedResult<ProjectFileDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListProjectFilesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<ProjectFileDto>>> Handle(ListProjectFilesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<ProjectFileDto>>();
            response.Value = await _dbContext.ProjectFiles
                .AsNoTracking()
                .OrderByDescending(item => item.Id)
                .Select(item => new ProjectFileDto
                {
                    Id = item.Id,
                    FileName = item.FileName, FilePath = item.FilePath, UploadTime = item.UploadTime
                })
                .GetPagedAsync(request.Page, request.PageSize, cancellationToken);

            return response;
        }
    }
}
