namespace MoviesApi.Modelos.Dtos
{
    public class MovieDetailsDto
    {
        public int Id { get; set; }
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public int Budget { get; set; }
        public List<GenreDto> Genres { get; set; } = new List<GenreDto>();
        public string Homepage { get; set; }
        public string ImdbId { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public float Popularity { get; set; }
        public string PosterPath { get; set; }
        public List<ProductionCompanyDto> ProductionCompanies { get; set; } = new List<ProductionCompanyDto>();
        public List<ProductionCountryDto> ProductionCountries { get; set; } = new List<ProductionCountryDto>();
        public string ReleaseDate { get; set; }
        public int Revenue { get; set; }
        public int Runtime { get; set; }
        public List<SpokenLanguageDto> SpokenLanguages { get; set; } = new List<SpokenLanguageDto>();
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public float VoteAverage { get; set; }
        public int VoteCount { get; set; }
    }

    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductionCompanyDto
    {
        public int Id { get; set; }
        public string LogoPath { get; set; }
        public string Name { get; set; }
        public string OriginCountry { get; set; }
    }

    public class ProductionCountryDto
    {
        public string LanguageCode { get; set; }
        public string Name { get; set; }
    }

    public class SpokenLanguageDto
    {
        public string EnglishName { get; set; }
        public string LanguageCode { get; set; }
        public string Name { get; set; }
    }
}
