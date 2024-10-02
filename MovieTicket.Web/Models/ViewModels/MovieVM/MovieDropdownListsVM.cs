namespace MovieTicket.Web.Models.ViewModels.MovieVM
{
    public class MovieDropdownListsVM
    {
        public MovieDropdownListsVM()
        {
            Producers = new List<Producer>();
            Actors = new List<Actor>();
            Categories = new List<Category>();
            Cinemas = new List<Cinema>();
        }

        public List<Producer> Producers { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Category> Categories { get; set; }
        public List<Cinema> Cinemas { get; set; }
    }
}
