using FluentValidation;

namespace MovieTicket.Web.Models.ModelValidations
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(n => n.Name)
                .NotNull()
                .NotEmpty()
                .Length(3, 30);

            RuleFor(d => d.Description)
                .NotEmpty()
                .NotNull()
                .Length(3, 500);

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(1m);

            RuleFor(p => p.PictureUrl)
                .NotEmpty()
                .NotNull()
                .Length(3, 500);

            RuleFor(s => s.StartDate)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(new DateTime(1900, 1, 1));


            RuleFor(e => e.EndDate)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(new DateTime(1900, 1, 1))
                .GreaterThan(s => s.StartDate);
        }
    }
}