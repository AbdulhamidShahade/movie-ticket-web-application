using MovieTicket.Web.Models.Base;

namespace MovieTicket.Web.Models
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
    }
}
