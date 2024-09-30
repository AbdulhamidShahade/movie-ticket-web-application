using FluentValidation;
using MovieTicket.Web.Models.Base;

namespace MovieTicket.Web.Models.ModelValidations
{
    public class EntityBaseValidator : AbstractValidator<EntityBase>
    {
        public EntityBaseValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.CreatedAt)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(DateTime.UtcNow);

            RuleFor(u => u.UpdatedAt)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(DateTime.UtcNow);
        }
    }
}
