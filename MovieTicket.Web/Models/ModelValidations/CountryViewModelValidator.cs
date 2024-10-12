using FluentValidation;
using MovieTicket.Web.Models.ViewModels.CountryVM;

namespace MovieTicket.Web.Models.ModelValidations
{
    public class CountryViewModelValidator : AbstractValidator<ReadCountryVM>
    {
        public CountryViewModelValidator()
        {
            RuleFor(p => p.PhoneCode)
                .NotEmpty()
                .WithMessage("Phone Code");
        }
    }
}
