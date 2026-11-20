using MediatR;
using KooliProjekt.Application.Infrastructure.Results;

namespace KooliProjekt.Application.Features.Authentication
{
    public class AuthenticateCommand : IRequest<OperationResult<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}