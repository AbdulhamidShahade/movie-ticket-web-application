using FluentValidation;

namespace MovieTicket.Web.Models.ModelValidations
{
    public class MovieActorValidator : AbstractValidator<MovieActor>
    {
        public MovieActorValidator()
        {
            RuleFor(m => m.MovieId)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(1);

            RuleFor(m => m.Movie)
                .NotEmpty()
                .NotNull();

            RuleFor(a => a.ActorId)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(1);

            RuleFor(a => a.Actor)
                .NotNull()
                .NotEmpty();
        }
    }
}