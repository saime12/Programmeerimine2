using MediatR;
using System;
using KooliProjekt.Application.Infrastructure.Results;

namespace KooliProjekt.Application.Features.Users
{
    public class SaveUserCommand : IRequest<OperationResult<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
