using MediatR;
using System;
using KooliProjekt.Application.Infrastructure.Results;

namespace KooliProjekt.Application.Features.WorkLogs
{
    public class SaveWorkLogCommand : IRequest<OperationResult<int>>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double TimeSpent { get; set; }
        public string Description { get; set; }
    }
}
