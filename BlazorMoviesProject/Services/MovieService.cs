using BlazorMoviesProject.Helpers;
using BlazorMoviesProject.Models;
using BlazorMoviesProject.Services.IServices;
using Newtonsoft.Json;
using System.Text;

namespace BlazorMoviesProject.Services
{
    public class MovieService : IMovieService
    {

        private readonly HttpClient _httpClient;

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MovieDetails> CreateMovie(MovieDetails movie)
        {
            var content = JsonConvert.SerializeObject(movie);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{Inicializar.UrlBaseApi}api/moviedetails", bodyContent);

            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<MovieDetails>(contentTemp);
                return result;
            }
            else
            {
                var contentTemp = await response.Content?.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ModeloError>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<List<Genre>> GetAvailableGenres()
        {
            var response = await _httpClient.GetAsync($"{Inicializar.UrlBaseApi}api/genres");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var genres = JsonConvert.DeserializeObject<List<Genre>>(content);
                return genres;
            }
            else
            {
                var errorContent = await response.Content?.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ModeloError>(errorContent);
                throw new Exception(errorModel.ErrorMessage);
            }
        }


        public async Task<bool> DeleteMovie(int movieId)
        {
            var response = await _httpClient.DeleteAsync($"{Inicializar.UrlBaseApi}api/moviedetails/{movieId}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();

                var errorModel = JsonConvert.DeserializeObject<ModeloError>(content);

                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<MovieDetails> GetMovieById(int movieId)
        {
            var response = await _httpClient.GetAsync($"{Inicializar.UrlBaseApi}api/moviedetails/{movieId}");



            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var movie = JsonConvert.DeserializeObject<MovieDetails>(content);

                return movie;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();

                var errorModel = JsonConvert.DeserializeObject<ModeloError>(content);

                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<IEnumerable<MovieDetails>> GetMovies()
        {
            var response = await _httpClient.GetAsync($"{Inicializar.UrlBaseApi}api/moviedetails");

            //inicializar es una clase creada en la carpeta helpers donde hemos puesto la url de nuestra api

            var content = await response.Content.ReadAsStringAsync();

            var movies = JsonConvert.DeserializeObject<IEnumerable<MovieDetails>>(content);

            return movies;
        }



        //public async Task<MovieDetails> UpdateMovie(int movieId, MovieDetails movie)
        //{
        //    var content = JsonConvert.SerializeObject(movie);
        //    var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        //    try
        //    {
        //        var response = await _httpClient.PatchAsync($"{Inicializar.UrlBaseApi}api/moviedetails/{movieId}", bodyContent);

        //        if (response.IsSuccessStatusCode)
        //        {


        //            var contentTemp = await response.Content.ReadAsStringAsync();
        //            return JsonConvert.DeserializeObject<MovieDetails>(contentTemp);
        //        }
        //        else
        //        {
        //            var errorContent = await response.Content.ReadAsStringAsync();
        //            var errorModel = JsonConvert.DeserializeObject<ModeloError>(errorContent);
        //            throw new Exception($"Error updating movie: {errorModel.ErrorMessage}", new Exception($"HTTP {errorModel.StatusCode}: {errorModel.Tittle}"));
        //        }
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        throw new Exception("Connection to API failed", e);
        //    }
        //    catch (JsonException e)
        //    {
        //        throw new Exception("Error parsing response from the server", e);
        //    }
        //}

        public async Task<bool> UpdateMovie(int movieId, MovieDetails movie)
        {
            var content = JsonConvert.SerializeObject(movie);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PatchAsync($"{Inicializar.UrlBaseApi}api/moviedetails/{movieId}", bodyContent);

                if (response.IsSuccessStatusCode)
                {
                    // Verificar si el cuerpo de la respuesta está vacío
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        // No hay contenido para procesar, asumimos éxito
                        return true;
                    }

                    var contentTemp = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(contentTemp))
                    {
                        var updatedMovie = JsonConvert.DeserializeObject<MovieDetails>(contentTemp);
                        // Retorna verdadero si el objeto deserializado es válido
                        return updatedMovie != null;
                    }
                    else
                    {
                        // No hubo errores, pero tampoco contenido en la respuesta
                        return true;
                    }
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    var errorModel = JsonConvert.DeserializeObject<ModeloError>(errorContent);
                    throw new Exception($"Error updating movie: {errorModel.ErrorMessage}", new Exception($"HTTP {errorModel.StatusCode}: {errorModel.Tittle}"));
                }
            }
            catch (HttpRequestException e)
            {
                throw new Exception("Connection to API failed", e);
            }
            catch (JsonException e)
            {
                throw new Exception("Error parsing response from the server", e);
            }
        }





        public async Task<string> SubidaDeImagen(MultipartFormDataContent content)
        {
            var movieResult = await _httpClient.PostAsync($"{Inicializar.UrlBaseApi}api/moviedetails/Upload", content);

            var movieContent = await movieResult.Content.ReadAsStringAsync();

            if (!movieResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(movieContent);
            }
            else
            {
                var imagenMovie = Path.Combine(Inicializar.UrlBaseApi, movieContent);
                return imagenMovie;
            }
        }

    }
}
