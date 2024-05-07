using Microsoft.EntityFrameworkCore;
using MoviesApi.Modelos;

namespace MoviesApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<MovieDetails> MoviesDetails { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<ProductionCompany> ProductionCompanies { get; set; }

        public DbSet<ProductionCountry> ProductionCountries { get; set; }

        public DbSet<SpokenLanguage> SpokenLanguages { get; set; }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
