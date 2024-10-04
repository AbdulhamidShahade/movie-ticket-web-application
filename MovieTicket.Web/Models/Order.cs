using MovieTicket.Web.Models.Base;

namespace MovieTicket.Web.Models
{
    public class Order : EntityBase
    {
        public string Email { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }
    }
}
