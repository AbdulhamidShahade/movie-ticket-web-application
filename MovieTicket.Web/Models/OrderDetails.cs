using MovieTicket.Web.Models.Base;

namespace MovieTicket.Web.Models
{
    public class OrderDetails : EntityBase
    {
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public bool IsActive { get; set; }
    }
}