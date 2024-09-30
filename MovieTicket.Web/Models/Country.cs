using MovieTicket.Web.Models.Base;

namespace MovieTicket.Web.Models
{
    public class Country : EntityBase
    {
        public string Name { get; set; }
        public string? Iso { get; set; }
        public string Nicename { get; set; }
        public string? Iso3 { get; set; }
        public int? NumCode { get; set; }
        public int? PhoneCode { get; set; }
        public string? PictureUrl { get; set; }

        public List<Producer> Producers { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
