using FluentValidation;

namespace MovieTicket.Web.Models.ModelValidations
{
    public class MovieProducerValidator : AbstractValidator<MovieProducer>
    {
        public MovieProducerValidator()
        {
            RuleFor(m => m.MovieId)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(1);

            RuleFor(m => m.Movie)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.ProducerId)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(1);

            RuleFor(p => p.Producer)
                .NotEmpty()
                .NotNull();
        }
    }
}