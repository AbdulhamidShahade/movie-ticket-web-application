using MovieTicket.Web.Models.Base;

namespace MovieTicket.Web.Models
{
    public abstract class Person : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }
        public string PictureUrl { get; set; }
        public abstract string FullName();
    }
}
