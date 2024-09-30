namespace MovieTicket.Web.Models
{
    public class Producer : Person
    {
        public override string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
