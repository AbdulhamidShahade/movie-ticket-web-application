namespace MovieTicket.Web.Models.ViewModels.ProducerVM
{
    public class ReadProducerVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Bio { get; set; }
        public string PictureUrl { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
