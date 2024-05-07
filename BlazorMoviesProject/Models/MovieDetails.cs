using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorMoviesProject.Models
{


    public class MovieDetails
    {


        // Constructor para inicializar las propiedades
        public MovieDetails()
        {
            // Inicializar la lista de géneros
            Genres = new List<Genre>();

            // Puedes hacer lo mismo para otras listas si es necesario
            ProductionCompanies = new List<ProductionCompany>();
            ProductionCountries = new List<ProductionCountry>();
            SpokenLanguages = new List<SpokenLanguage>();

        }

        public int Id { get; set; }


        public bool Adult { get; set; }

        public string? BackdropPath { get; set; }

        public int Budget { get; set; }


        //[ValidateComplexType]
        public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();

        public string? Homepage { get; set; }

        public string? ImdbId { get; set; }

        public string? OriginalLanguage { get; set; }

        public string? OriginalTitle { get; set; }

        public string? Overview { get; set; }

        public float Popularity { get; set; }

        public string? PosterPath { get; set; }

        //[ValidateComplexType]
        public virtual ICollection<ProductionCompany> ProductionCompanies { get; set; } = new List<ProductionCompany>();


        //[ValidateComplexType]
        public virtual ICollection<ProductionCountry> ProductionCountries { get; set; } = new List<ProductionCountry>();

        public string? ReleaseDate { get; set; }

        //private DateTime? _releaseDate;

        //// Esta es la propiedad que usarás con InputDate
        //public DateTime? ReleaseDate
        //{
        //    get => _releaseDate;
        //    set => _releaseDate = value;
        //}

        //// Si aún necesitas manejar la fecha como string por alguna razón específica, puedes mantener este método
        //public string ReleaseDateString
        //{
        //    get => _releaseDate?.ToString("yyyy-MM-dd");
        //    set => _releaseDate = DateTime.TryParse(value, out DateTime temp) ? temp : null;
        //}


        //[JsonIgnore] // Ignorar para la serialización de la API, solo para uso en UI
        //public DateTime ReleaseDateAsDateTime
        //{
        //    get => DateTime.TryParse(ReleaseDate, out var date) ? date : DateTime.Now; // Convierte de string a DateTime para la UI
        //    set => ReleaseDate = value.ToString("yyyy-MM-dd"); // Convierte de DateTime a string cuando se establece
        //}

        public int Revenue { get; set; }

        public int Runtime { get; set; }


        //[ValidateComplexType]
        public virtual ICollection<SpokenLanguage> SpokenLanguages { get; set; } = new List<SpokenLanguage>();

        public string? Status { get; set; }

        public string? Tagline { get; set; }


        public string? Title { get; set; }

        public bool Video { get; set; }

        public float VoteAverage { get; set; }

        public int VoteCount { get; set; }
    }

    public class Genre
    {

        public int Id { get; set; }


        public string? Name { get; set; }
    }

    public class ProductionCompany
    {

        public int Id { get; set; }

        public string? LogoPath { get; set; }


        public string? Name { get; set; }

        public string? OriginCountry { get; set; }
    }

    public class ProductionCountry
    {

        public int Id { get; set; }

        public string? LanguageCode { get; set; }


        public string? Name { get; set; }
    }

    public class SpokenLanguage
    {

        public int Id { get; set; }

        public string? EnglishName { get; set; }

        public string? LanguageCode { get; set; }


        public string? Name { get; set; }
    }
}



