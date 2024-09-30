using FluentValidation;
using MovieTicket.Web.Models;

namespace MovieTicket.Web.Models.ModelValidations
{
    public class CinemaValidator : AbstractValidator<Cinema>
    {
        public CinemaValidator()
        {
            RuleFor(n => n.Name)
                .NotEmpty()
                .NotNull()
                .Length(3, 50);

            RuleFor(l => l.Logo)
                .NotEmpty()
                .NotNull()
                .Length(3, 500);

            RuleFor(d => d.Description)
                .NotEmpty()
                .NotNull()
                .Length(3, 500);
        }
    }
}
