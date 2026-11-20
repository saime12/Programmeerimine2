using KooliProjekt.Application.Authentication;
using KooliProjekt.Application.Authentication.Jwt;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Authentication
{
    public class AuthenticateCommandHandler
        : IRequestHandler<AuthenticateCommand, OperationResult<string>>
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtTokenBuilder _tokenBuilder;

        public AuthenticateCommandHandler(
            ApplicationDbContext context,
            JwtTokenBuilder tokenBuilder)
        {
            _context = context;
            _tokenBuilder = tokenBuilder;
        }

        public async Task<OperationResult<string>> Handle(
            AuthenticateCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(
                    u => u.Email == request.Email,
                    cancellationToken);

            if (user == null)
            {
                return new OperationResult<string>()
                    .AddError("Invalid email or password.");
            }

            if (!PasswordHelper.Verify(request.Password, user.Password))
            {
                return new OperationResult<string>()
                    .AddError("Invalid email or password.");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };

            if (user.IsAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }

            var token = _tokenBuilder.GenerateToken(claims.ToArray());

            return new OperationResult<string>(token);
        }
    }
}