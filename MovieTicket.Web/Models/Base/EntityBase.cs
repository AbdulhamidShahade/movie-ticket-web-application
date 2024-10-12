namespace MovieTicket.Web.Models.Base
{
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedAt
        {
            get; set;
        }
        public DateTime? UpdatedAt
        {
            get
            {
                return DateTime.UtcNow;
            }
            set { }
        }
    }
}
