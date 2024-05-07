using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Modelos;
using MoviesApi.Modelos.Dtos;
using MoviesApi.Services.IServices;

namespace MoviesApi.Controllers
{
    [Route("api/moviedetails")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieDetailsService _movieDetailsService;

        private readonly IMapper _mapper;

        public MoviesController(IMovieDetailsService movieDetailsService, IMapper mapper)
        {
            _movieDetailsService = movieDetailsService;
            _mapper = mapper;
        }

        //[AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]

        public ActionResult<MovieDetails> GetMovies()
        {
            var listaDePeliculas = _movieDetailsService.GetMovies();

            var listaDePeliculasDto = new List<MovieDetailsDto>();

            foreach (var movie in listaDePeliculas)
            {
                listaDePeliculasDto.Add(_mapper.Map<MovieDetailsDto>(movie));
            }

            return Ok(listaDePeliculasDto);
        }



        [Route("api/genres")]
        [HttpGet]
        public ActionResult<IEnumerable<Genre>> GetGenres()
        {
            var genres = _movieDetailsService.GetGenres();
            return Ok(genres);
        }


        //[AllowAnonymous]
        [HttpGet("{movieId:int}", Name = "GetMovie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public ActionResult<MovieDetails> GetMovie(int movieId)
        {
            var itemPost = _movieDetailsService.GetMovie(movieId);

            if (itemPost == null)
            {
                return NotFound();
            }

            var itemPostDto = _mapper.Map<MovieDetailsDto>(itemPost);

            return Ok(itemPostDto);
        }

        //[Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(MovieDetailsDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostMovie([FromBody] MovieDetailsDto movieDetailsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_movieDetailsService.MovieExists(movieDetailsDto.Title))
            {
                ModelState.AddModelError("", "La pelicula ya existe");
                return StatusCode(404, ModelState);

            }

            var movieDetails = _mapper.Map<MovieDetails>(movieDetailsDto);

            if (!_movieDetailsService.CreateMovie(movieDetails))
            {
                ModelState.AddModelError("", $"Algo salio mal guardando el registro {movieDetails.Title}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetMovie", new { movieId = movieDetails.Id }, movieDetails);
        }
        //[Authorize]
        //[Authorize]
        [HttpPatch("{movieId:int}", Name = "UpdateMovie")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateMovie(int movieId, [FromBody] MovieDetailsDto movieDetailsDto)
        {
            if (!ModelState.IsValid || movieId < 1)
            {
                return BadRequest(ModelState);
            }

            if (movieDetailsDto == null || movieId != movieDetailsDto.Id)
            {
                return BadRequest("The movie ID provided in the URL does not match the ID in the data.");
            }

            var movieToUpdate = _mapper.Map<MovieDetails>(movieDetailsDto);

            var updateResult = _movieDetailsService.UpdateMovie(movieToUpdate);
            if (!updateResult)
            {
                ModelState.AddModelError("", $"Something went wrong updating the record {movieToUpdate.Title}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [Authorize]
        [HttpDelete("{movieId:int}", Name = "BorrarPost")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult BorrarMovie(int movieId)
        {

            if (!_movieDetailsService.MovieExists(movieId))
            {
                return NotFound();
            }

            var movie = _movieDetailsService.GetMovie(movieId);

            if (!_movieDetailsService.DeleteMovie(movie))
            {
                ModelState.AddModelError("", $"Algo salio mal borrando el registro {movie.Title}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }










    }
}
