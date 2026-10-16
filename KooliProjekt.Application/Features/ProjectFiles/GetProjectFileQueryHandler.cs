using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.ProjectFiles
{
    public class GetProjectFileQueryHandler : IRequestHandler<GetProjectFileQuery, ProjectFile>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetProjectFileQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProjectFile> Handle(GetProjectFileQuery request, CancellationToken cancellationToken)
        {
            var file = await _dbContext.ProjectFiles.FindAsync(request.Id, cancellationToken);

            return file;
        }
    }
}
