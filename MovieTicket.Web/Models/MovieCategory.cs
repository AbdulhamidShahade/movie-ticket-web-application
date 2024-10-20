using MovieTicket.Web.Models.Base;

namespace MovieTicket.Web.Models
{
    public class MovieCategory : EntityBase
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}