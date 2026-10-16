using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.WorkLogs
{
    public class GetWorkLogQuery : IRequest<WorkLog>
    {
        public int Id { get; set; }
    }
}
