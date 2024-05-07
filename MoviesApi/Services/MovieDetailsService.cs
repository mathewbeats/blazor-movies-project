using MoviesApi.Data;
using MoviesApi.Modelos;
using MoviesApi.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace MoviesApi.Services
{
    public class MovieDetailsService : IMovieDetailsService
    {
        private readonly ApplicationDbContext _context;

        public MovieDetailsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateMovie(MovieDetails movieDetails)
        {
            _context.MoviesDetails.Add(movieDetails);
            return Save();
        }

        public bool DeleteMovie(MovieDetails movieDetails)
        {
            _context.Remove(movieDetails);

            return Save();
        }

        public MovieDetails GetMovie(int movieId)
        {
            if(movieId == 0)
            {
                return null;
            }

           return _context.MoviesDetails.FirstOrDefault(m => m.Id == movieId);
        }

        public ICollection<MovieDetails> GetMovies()
        {
            return _context.MoviesDetails.OrderBy(m => m.Id).ToList();
        }

        public bool MovieExists(int movieId)
        {
            bool valor = _context.MoviesDetails.Any(m => m.Id == movieId);

            return valor;
        }

        public bool MovieExists(string tittle)
        {
            bool valor = _context.MoviesDetails.Any(m => m.Title.ToLower().Trim() == tittle.ToLower().Trim());

            return valor;
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public bool UpdateMovie(MovieDetails movieDetails)
        {
           

            var imagenDesdeBd = _context.MoviesDetails.AsNoTracking().FirstOrDefault(c => c.Id == movieDetails.Id);

            //si quiero actualizar una imagen, se actualiza
            //pero si quiero actualizar un nombre y no la imagen daria error entonces ponemos AsNoTracking


            if (movieDetails.PosterPath == null)
            {
                movieDetails.PosterPath = imagenDesdeBd.PosterPath;
            }



            _context.MoviesDetails.Update(movieDetails);

            return Save();
        }


        public List<Genre> GetGenres()
        {
            return _context.Genres.OrderBy(g => g.Name).ToList();
        }
    }
}
