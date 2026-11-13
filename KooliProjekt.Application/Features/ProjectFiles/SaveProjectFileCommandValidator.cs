
using FluentValidation;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProjectFiles
{
    public class SaveProjectFileCommandValidator
        : AbstractValidator<SaveProjectFileCommand>
    {
        public SaveProjectFileCommandValidator(
            ApplicationDbContext dbContext)
        {
            RuleFor(x => x.ProjectTaskId)
                .GreaterThan(0)
                .WithMessage("Ülesande ID peab olema suurem kui 0.")
                .MustAsync(async (id, cancellationToken) =>
                    await dbContext.ProjectTasks.AnyAsync(
                        task => task.Id == id,
                        cancellationToken))
                .WithMessage("Sellist ülesannet ei leitud.");

            RuleFor(x => x.FileName)
                .NotEmpty()
                .WithMessage("Faili nimi on kohustuslik.")
                .MaximumLength(255)
                .WithMessage("Faili nimi võib olla maksimaalselt 255 tähemärki.");

            RuleFor(x => x.InputStream)
                .NotNull()
                .WithMessage("Faili sisu on kohustuslik.");
        }
    }
}
