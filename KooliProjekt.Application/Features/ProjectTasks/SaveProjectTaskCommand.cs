using MediatR;
using System;
using KooliProjekt.Application.Infrastructure.Results;

namespace KooliProjekt.Application.Features.ProjectTasks
{
    public class SaveProjectTaskCommand : IRequest<OperationResult<int>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan EstimatedTime { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public decimal? FixedPrice { get; set; }
    }
}
