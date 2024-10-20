using MovieTicket.Web.Models.Base;

namespace MovieTicket.Web.Models
{
    public class MovieProducer : EntityBase
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
    }
}