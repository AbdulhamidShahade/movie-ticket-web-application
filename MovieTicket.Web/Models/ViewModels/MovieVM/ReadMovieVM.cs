namespace MovieTicket.Web.Models.ViewModels.MovieVM
{
    public class ReadMovieVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Length { get; set; }
        public int PublishYear { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CinemaId { get; set; }
        public decimal Rating { get; set; }
    }
}
