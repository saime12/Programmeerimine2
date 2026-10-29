using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.WorkLogs
{
    public class GetWorkLogQuery : IRequest<OperationResult<WorkLogDto>>
    {
        public int Id { get; set; }
    }
}
