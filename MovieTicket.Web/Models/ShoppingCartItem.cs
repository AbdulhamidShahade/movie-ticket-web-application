using MovieTicket.Web.Models.Base;

namespace MovieTicket.Web.Models
{
    public class ShoppingCartItem : EntityBase
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int Amount { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}