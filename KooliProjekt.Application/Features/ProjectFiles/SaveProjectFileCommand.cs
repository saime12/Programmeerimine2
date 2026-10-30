using MediatR;
using System;
using KooliProjekt.Application.Infrastructure.Results;

namespace KooliProjekt.Application.Features.ProjectFiles
{
    public class SaveProjectFileCommand : IRequest<OperationResult<int>>
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadTime { get; set; }
    }
}
