using MovieTicket.Web.Models.Base;

namespace MovieTicket.Web.Models
{
    public class MovieActor : EntityBase
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}