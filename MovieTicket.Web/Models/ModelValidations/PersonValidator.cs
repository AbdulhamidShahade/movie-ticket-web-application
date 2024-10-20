using FluentValidation;

namespace MovieTicket.Web.Models.ModelValidations
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(f => f.FirstName)
                .NotEmpty()
                .NotNull()
                .Length(3, 30);
                

            RuleFor(l => l.LastName)
                .NotEmpty()
                .NotNull()
                .Length(3, 30);

            RuleFor(b => b.BirthDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(new DateTime(1900, 1, 1))
                .NotNull();

            RuleFor(b => b.Bio)
                .NotEmpty()
                .NotNull()
                .Length(3, 500);

            RuleFor(p => p.PictureUrl)
                .NotEmpty()
                .NotNull()
                .Length(3, 500);
        }
    }
}