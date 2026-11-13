
using FluentValidation;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProjectFiles
{
    public class GetProjectFileQueryValidator
        : AbstractValidator<GetProjectFileQuery>
    {
        public GetProjectFileQueryValidator(
            ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Faili ID peab olema suurem kui 0.")
                .MustAsync(async (id, cancellationToken) =>
                    await dbContext.ProjectFiles.AnyAsync(
                        file => file.Id == id,
                        cancellationToken))
                .WithMessage("Sellist faili ei leitud.");
        }
    }
}
