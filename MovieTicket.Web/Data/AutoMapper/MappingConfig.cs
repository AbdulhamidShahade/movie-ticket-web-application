using AutoMapper;
using MovieTicket.Web.Models;
using MovieTicket.Web.Models.ViewModels.ActorVM;
using MovieTicket.Web.Models.ViewModels.CategoryVM;
using MovieTicket.Web.Models.ViewModels.CinemaVM;
using MovieTicket.Web.Models.ViewModels.CountryVM;
using MovieTicket.Web.Models.ViewModels.MovieVM;
using MovieTicket.Web.Models.ViewModels.ProducerVM;

namespace MovieTicket.Web.Data.AutoMapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Category, CreateCategoryVM>().ReverseMap();
            CreateMap<Category, UpdateCategoryVM>().ReverseMap();
            CreateMap<Category, ReadCategoryVM>().ReverseMap();
            CreateMap<Category, DeleteCategoryVM>().ReverseMap();


            CreateMap<Cinema, ReadCinemaVM>().ReverseMap();
            CreateMap<Cinema, UpdateCinemaVM>().ReverseMap();
            CreateMap<Cinema, DeleteCinemaVM>().ReverseMap();
            CreateMap<Cinema, CreateCinemaVM>().ReverseMap();


            CreateMap<Actor, ReadActorVM>().ReverseMap();
            CreateMap<Actor, UpdateActorVM>().ReverseMap();
            CreateMap<Actor, DeleteActorVM>().ReverseMap();
            CreateMap<Actor, CreateActorVM>().ReverseMap();


            CreateMap<Producer, ReadProducerVM>().ReverseMap();
            CreateMap<Producer, UpdateProducerVM>().ReverseMap();
            CreateMap<Producer, DeleteProducerVM>().ReverseMap();
            CreateMap<Producer, CreateProducerVM>().ReverseMap();


            CreateMap<Movie, ReadMovieVM>().ReverseMap();
            CreateMap<Movie, DeleteMovieVM>().ReverseMap();
            CreateMap<Movie, UpdateMovieVM>().ReverseMap();




            CreateMap<Country, ReadCountryVM>().ReverseMap();
            CreateMap<Country, CreateCountryVM>().ReverseMap();
            CreateMap<Country, UpdateCountryVM>().ReverseMap();
            CreateMap<Country, DeleteCountryVM>().ReverseMap();    
        }
    }
}
