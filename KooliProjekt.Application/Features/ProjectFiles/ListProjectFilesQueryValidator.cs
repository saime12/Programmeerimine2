
using FluentValidation;

namespace KooliProjekt.Application.Features.ProjectFiles
{
    public class ListProjectFilesQueryValidator
        : AbstractValidator<ListProjectFilesQuery>
    {
        public ListProjectFilesQueryValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Lehekülje number peab olema suurem kui 0.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("Lehekülje suurus peab olema suurem kui 0.")
                .LessThanOrEqualTo(100)
                .WithMessage("Lehekülje suurus ei tohi olla suurem kui 100.");
        }
    }
}
