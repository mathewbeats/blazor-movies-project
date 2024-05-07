using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Modelos
{
    public class MovieDetails
    {
        [Key]
        public int Id { get; set; }

        
        public bool Adult { get; set; }

        public string? BackdropPath { get; set; }

        public int Budget { get; set; }

        public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();

        public string? Homepage { get; set; }

        public string? ImdbId { get; set; }

        public string? OriginalLanguage { get; set; }

        public string? OriginalTitle { get; set; }

        public string? Overview { get; set; }

        public float Popularity { get; set; }

        public string? PosterPath { get; set; }

        public virtual ICollection<ProductionCompany> ProductionCompanies { get; set; } = new List<ProductionCompany>();

        public virtual ICollection<ProductionCountry> ProductionCountries { get; set; } = new List<ProductionCountry>();

        public string? ReleaseDate { get; set; }

        public int Revenue { get; set; }

        public int Runtime { get; set; }

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
        [Key]
        public int Id { get; set; }

       
        public string? Name { get; set; }
    }

    public class ProductionCompany
    {
        [Key]
        public int Id { get; set; }

        public string? LogoPath { get; set; }

       
        public string? Name { get; set; }

        public string? OriginCountry { get; set; }
    }

    public class ProductionCountry
    {
        [Key]
        public int Id { get; set; }

        public string? LanguageCode { get; set; }

       
        public string? Name { get; set; }
    }

    public class SpokenLanguage
    {
        [Key]
        public int Id { get; set; }

        public string? EnglishName { get; set; }

        public string? LanguageCode { get; set; }

        
        public string? Name { get; set; }
    }
}
