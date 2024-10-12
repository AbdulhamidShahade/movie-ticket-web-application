namespace MovieTicket.Web.Models.Base
{
    public interface IEntityBase
    {
        int Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}