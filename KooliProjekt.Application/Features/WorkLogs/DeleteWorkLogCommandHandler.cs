using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.WorkLogs
{
    public class DeleteWorkLogCommandHandler : IRequestHandler<DeleteWorkLogCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteWorkLogCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteWorkLogCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var entity = await _dbContext.WorkLogs.FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                result.AddError("Kirjet ei leitud.");
                return result;
            }

            _dbContext.WorkLogs.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
