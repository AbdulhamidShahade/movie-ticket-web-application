using FluentValidation;

namespace MovieTicket.Web.Models.ModelValidations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(n => n.Name)
                .NotEmpty()
                .NotNull()
                .Length(3, 50);


            RuleFor(d => d.Description)
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