namespace MovieTicket.Web.Models.ViewModels.MovieVM
{
    public class ReadMovieVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int Length { get; set; }
        public int PublishYear { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
