using FluentValidation;

namespace MovieTicket.Web.Models.ModelValidations
{
    public class MovieCategoryValidator : AbstractValidator<MovieCategory>  
    {
        public MovieCategoryValidator()
        {
            RuleFor(m => m.MovieId)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(1);

            RuleFor(m => m.Movie)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.CategoryId)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(1);

            RuleFor(c => c.Category)
                .NotEmpty()
                .NotNull();
        }
    }
}