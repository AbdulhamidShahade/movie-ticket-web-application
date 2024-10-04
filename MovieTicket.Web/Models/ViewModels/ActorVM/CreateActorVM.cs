namespace MovieTicket.Web.Models.ViewModels.ActorVM
{
    public class CreateActorVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Bio { get; set; }
        public string PictureUrl { get; set; }
    }
}
