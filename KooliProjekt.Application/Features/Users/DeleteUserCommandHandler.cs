using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Users
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteUserCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();
            var entity = await _dbContext.Users.FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                result.AddError("Kirjet ei leitud.");
                return result;
            }

            _dbContext.Users.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
