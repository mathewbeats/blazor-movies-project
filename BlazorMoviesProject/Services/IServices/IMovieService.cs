using BlazorMoviesProject.Models;

namespace BlazorMoviesProject.Services.IServices
{
    public interface IMovieService
    {
        public Task<IEnumerable<MovieDetails>> GetMovies();

        public Task<MovieDetails> GetMovieById(int movieId);

        //public Task<MovieDetails> UpdateMovie(int movieId,MovieDetails movie);

        public Task<MovieDetails> CreateMovie(MovieDetails movie);

        public Task<bool> DeleteMovie(int movieId);

        public Task<string> SubidaDeImagen(MultipartFormDataContent content);

        public Task<List<Genre>> GetAvailableGenres();

        Task<bool> UpdateMovie(int movieId, MovieDetails movie);
    }
}
