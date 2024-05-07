using System.Text.Json.Serialization;

namespace BlazorMoviesProject.Models
{
    public class PopularMovieResponse
    {
       
        public int Page { get; set; }

    
        public List<MovieDetails> Results { get; set; } = new();
    }
}
