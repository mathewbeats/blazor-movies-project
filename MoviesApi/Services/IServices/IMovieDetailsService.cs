using MoviesApi.Modelos;

namespace MoviesApi.Services.IServices
{
    public interface IMovieDetailsService
    {
        ICollection<MovieDetails> GetMovies();

        MovieDetails GetMovie(int movieId);

        bool MovieExists(int movieId);

        bool MovieExists(string tittle);

        bool CreateMovie(MovieDetails movieDetails);

        bool UpdateMovie(MovieDetails movieDetails);

        bool DeleteMovie(MovieDetails movieDetails);

        bool Save();

        List<Genre> GetGenres();


    }
}
