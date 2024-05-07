using AutoMapper;
using MoviesApi.Modelos;
using MoviesApi.Modelos.Dtos;

namespace MoviesApi.MoviesMapper
{
    public class MoviesMapper:Profile
    {
        public MoviesMapper()
        {
            // Mapeo bidireccional entre MovieDetails y MovieDetailsDto
            CreateMap<MovieDetails, MovieDetailsDto>().ReverseMap();

            // Mapeos bidireccionales para las subclases relacionadas y sus DTOs
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<ProductionCompany, ProductionCompanyDto>().ReverseMap();
            CreateMap<ProductionCountry, ProductionCountryDto>().ReverseMap();
            CreateMap<SpokenLanguage, SpokenLanguageDto>().ReverseMap();

            // Si tienes otras entidades y DTOs relacionados con MovieDetails, inclúyelos aquí
            // Por ejemplo, si tienes una entidad Actor y un ActorDto, agregarías:
            // CreateMap<Actor, ActorDto>().ReverseMap();
            // ... y así sucesivamente para otras entidades y DTOs relevantes
        }
    }
}
