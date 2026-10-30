using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Users
{
    public class SaveUserCommandHandler : IRequestHandler<SaveUserCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveUserCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveUserCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();
            User entity;

            if (request.Id > 0)
            {
                entity = await _dbContext.Users.FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);
                if (entity == null)
                {
                    result.AddError("Kirjet ei leitud.");
                    return result;
                }
            }
            else
            {
                entity = new User();
                _dbContext.Users.Add(entity);
            }

            entity.Name = request.Name;
            entity.Email = request.Email;
            entity.Password = request.Password;
            await _dbContext.SaveChangesAsync(cancellationToken);
            result.Value = entity.Id;
            return result;
        }
    }
}
