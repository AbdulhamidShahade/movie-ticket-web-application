namespace MovieTicket.Web.Models
{
    public class Actor : Person
    {
        public override string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }


        public List<MovieActor> MoviesActors { get; set; }
    }
}
