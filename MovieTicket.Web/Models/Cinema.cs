using MovieTicket.Web.Models.Base;

namespace MovieTicket.Web.Models
{
    public class Cinema : EntityBase
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }

        public List<Movie> Movies { get; set; }
    }
}