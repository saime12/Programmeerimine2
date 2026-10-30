using MediatR;
using System;
using KooliProjekt.Application.Infrastructure.Results;

namespace KooliProjekt.Application.Features.Projects
{
    public class SaveProjectCommand : IRequest<OperationResult<int>>
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public decimal Budget { get; set; }
        public decimal HourlyRate { get; set; }
    }
}
