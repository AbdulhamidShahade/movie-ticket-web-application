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

            CreateMap<Category, UpdateCategoryVM>()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => DateOnly.FromDateTime(s.CreatedAt)))
                .ReverseMap()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => Convert.ToDateTime(s.CreatedAt)));

            CreateMap<Category, ReadCategoryVM>()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => DateOnly.FromDateTime(s.CreatedAt)))
                .ReverseMap()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => Convert.ToDateTime(s.CreatedAt)));

            CreateMap<Category, DeleteCategoryVM>()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => DateOnly.FromDateTime(s.CreatedAt)))
                .ReverseMap()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => Convert.ToDateTime(s.CreatedAt)));


            CreateMap<Cinema, ReadCinemaVM>()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => DateOnly.FromDateTime(s.CreatedAt)))
                .ReverseMap()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => Convert.ToDateTime(s.CreatedAt)));

            CreateMap<Cinema, UpdateCinemaVM>()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => DateOnly.FromDateTime(s.CreatedAt)))
                .ReverseMap()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => Convert.ToDateTime(s.CreatedAt)));

            CreateMap<Cinema, DeleteCinemaVM>()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => DateOnly.FromDateTime(s.CreatedAt)))
                .ReverseMap()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => Convert.ToDateTime(s.CreatedAt)));

            CreateMap<Cinema, CreateCinemaVM>().ReverseMap();


            CreateMap<Actor, ReadActorVM>()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => DateOnly.FromDateTime(s.CreatedAt)))
                .ForMember(b => b.BirthDate, b => b.MapFrom(s => DateOnly.FromDateTime(s.BirthDate)))
                .ReverseMap()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => Convert.ToDateTime(s.CreatedAt)))
                .ForMember(b => b.BirthDate, b => b.MapFrom(s => Convert.ToDateTime(s.CreatedAt)));

            CreateMap<Actor, UpdateActorVM>()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => DateOnly.FromDateTime(s.CreatedAt)))
                .ForMember(b => b.BirthDate, b => b.MapFrom(s => DateOnly.FromDateTime(s.BirthDate)))
                .ReverseMap()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => Convert.ToDateTime(s.CreatedAt)))
                .ForMember(b => b.BirthDate, b => b.MapFrom(s => Convert.ToDateTime(s.CreatedAt)));

            CreateMap<Actor, DeleteActorVM>()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => DateOnly.FromDateTime(s.CreatedAt)))
                .ForMember(b => b.BirthDate, b => b.MapFrom(s => DateOnly.FromDateTime(s.BirthDate)))
                .ReverseMap()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => Convert.ToDateTime(s.CreatedAt)))
                .ForMember(b => b.BirthDate, b => b.MapFrom(s => Convert.ToDateTime(s.CreatedAt)));

            CreateMap<Actor, CreateActorVM>().ReverseMap();


            CreateMap<Producer, ReadProducerVM>()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => DateOnly.FromDateTime(s.CreatedAt)))
                .ForMember(b => b.BirthDate, b => b.MapFrom(s => DateOnly.FromDateTime(s.BirthDate)))
                .ReverseMap()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => Convert.ToDateTime(s.CreatedAt)))
                .ForMember(b => b.BirthDate, b => b.MapFrom(s => Convert.ToDateTime(s.CreatedAt)));

            CreateMap<Producer, UpdateProducerVM>()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => DateOnly.FromDateTime(s.CreatedAt)))
                .ForMember(b => b.BirthDate, b => b.MapFrom(s => DateOnly.FromDateTime(s.BirthDate)))
                .ReverseMap()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => Convert.ToDateTime(s.CreatedAt)))
                .ForMember(b => b.BirthDate, b => b.MapFrom(s => Convert.ToDateTime(s.CreatedAt)));

            CreateMap<Producer, DeleteProducerVM>()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => DateOnly.FromDateTime(s.CreatedAt)))
                .ForMember(b => b.BirthDate, b => b.MapFrom(s => DateOnly.FromDateTime(s.BirthDate)))
                .ReverseMap()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => Convert.ToDateTime(s.CreatedAt)))
                .ForMember(b => b.BirthDate, b => b.MapFrom(s => Convert.ToDateTime(s.CreatedAt)));

            CreateMap<Producer, CreateProducerVM>().ReverseMap();


            CreateMap<Movie, ReadMovieVM>()
                .ForMember(s => s.StartDate, x => x.MapFrom(d => DateOnly.FromDateTime(d.StartDate)))
                .ForMember(s => s.EndDate, x => x.MapFrom(d => DateOnly.FromDateTime(d.EndDate)))
                .ForMember(s => s.CreatedAt, x => x.MapFrom(d => DateOnly.FromDateTime(d.CreatedAt)))
                .ReverseMap()
                .ForMember(s => s.StartDate, x => x.MapFrom(d => Convert.ToDateTime(d.StartDate)))
                .ForMember(s => s.EndDate, x => x.MapFrom(d => Convert.ToDateTime(d.EndDate)))
                .ForMember(s => s.CreatedAt, x => x.MapFrom(d => Convert.ToDateTime(d.CreatedAt)));

            CreateMap<Movie, DeleteMovieVM>()
                .ForMember(s => s.StartDate, x => x.MapFrom(d => DateOnly.FromDateTime(d.StartDate)))
                .ForMember(s => s.EndDate, x => x.MapFrom(d => DateOnly.FromDateTime(d.EndDate)))
                .ForMember(s => s.CreatedAt, x => x.MapFrom(d => DateOnly.FromDateTime(d.CreatedAt)))
                .ReverseMap()
                .ForMember(s => s.StartDate, x => x.MapFrom(d => Convert.ToDateTime(d.StartDate)))
                .ForMember(s => s.EndDate, x => x.MapFrom(d => Convert.ToDateTime(d.EndDate)))
                .ForMember(s => s.CreatedAt, x => x.MapFrom(d => Convert.ToDateTime(d.CreatedAt)));


            CreateMap<Country, ReadCountryVM>()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => DateOnly.FromDateTime(s.CreatedAt)))
                .ReverseMap()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => Convert.ToDateTime(s.CreatedAt)));


            CreateMap<Country, CreateCountryVM>();

            CreateMap<Country, UpdateCountryVM>()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => DateOnly.FromDateTime(s.CreatedAt)))
                .ReverseMap()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => Convert.ToDateTime(s.CreatedAt)));


            CreateMap<Country, DeleteCountryVM>()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => DateOnly.FromDateTime(s.CreatedAt)))
                .ReverseMap()
                .ForMember(d => d.CreatedAt, d => d.MapFrom(s => Convert.ToDateTime(s.CreatedAt)));
        }
    }
}
