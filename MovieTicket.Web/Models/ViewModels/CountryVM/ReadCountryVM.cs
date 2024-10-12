using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Web.Models.ViewModels.CountryVM
{
    public class ReadCountryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Iso { get; set; }
        public string Nicename { get; set; }
        public string? Iso3 { get; set; }
        public int? NumCode { get; set; }
        public int? PhoneCode { get; set; }
        public string? PictureUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
