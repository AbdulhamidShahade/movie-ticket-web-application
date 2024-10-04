namespace MovieTicket.Web.Models.ViewModels.MovieVM
{
    public class CreateMovieVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<int> ActorIds { get; set; }
        public List<int> ProducerIds { get; set; }
        public int CinemaId { get; set; }
    }
}
