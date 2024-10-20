using MovieTicket.Web.Models.Base;

namespace MovieTicket.Web.Models
{
    public class Movie : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int Length { get; set; }
        public int PublishYear { get; set; }
        public decimal Rating { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        public List<MovieActor> MoviesActors { get; set; }
        public List<MovieCategory> MoviesCategories { get; set; }
        public List<MovieProducer> MoviesProducers { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}