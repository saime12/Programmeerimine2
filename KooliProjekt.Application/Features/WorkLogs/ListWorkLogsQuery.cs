using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.WorkLogs
{
    public class ListWorkLogsQuery : IRequest<IEnumerable<WorkLog>>
    {
    }
}
