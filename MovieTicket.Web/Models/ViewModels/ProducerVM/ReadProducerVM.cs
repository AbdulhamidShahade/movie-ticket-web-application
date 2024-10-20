namespace MovieTicket.Web.Models.ViewModels.ProducerVM
{
    public class ReadProducerVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }
        public string PictureUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CountryId { get; set; }
    }
}