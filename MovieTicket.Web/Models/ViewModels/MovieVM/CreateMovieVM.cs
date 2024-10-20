namespace MovieTicket.Web.Models.ViewModels.MovieVM
{
    public class CreateMovieVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<int> ActorIds { get; set; }
        public List<int> ProducerIds { get; set; }
        public int CinemaId { get; set; }
        public decimal Rating { get; set; }
        public int PublishYear { get; set; }
        public int Length { get; set; }
    }
}