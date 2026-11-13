
using System.IO;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProjectFiles
{
    public class SaveProjectFileCommand : IRequest<OperationResult<int>>
    {
        public int Id { get; set; }
        public int ProjectTaskId { get; set; }
        public string FileName { get; set; }
        public Stream InputStream { get; set; }
    }
}
