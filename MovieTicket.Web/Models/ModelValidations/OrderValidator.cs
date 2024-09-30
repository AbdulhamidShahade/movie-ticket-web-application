using FluentValidation;
using MovieTicket.Web.Models;

namespace MovieTicket.Web.Models.ModelValidations
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(e => e.Email)
                .NotEmpty()
                .NotNull()
                .Length(10, 50)
                .EmailAddress();
        }
    }
}
