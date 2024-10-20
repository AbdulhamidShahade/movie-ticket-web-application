using FluentValidation;

namespace MovieTicket.Web.Models.ModelValidations
{
    public class OrderDetailsValidator : AbstractValidator<OrderDetails>
    {
        public OrderDetailsValidator()
        {
            RuleFor(a => a.Amount)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(1);

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(1m);

            RuleFor(m => m.MovieId)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(1);

            RuleFor(o => o.OrderId)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(1);
        }
    }
}