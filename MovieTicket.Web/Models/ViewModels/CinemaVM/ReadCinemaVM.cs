namespace MovieTicket.Web.Models.ViewModels.CinemaVM
{
    public class ReadCinemaVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
