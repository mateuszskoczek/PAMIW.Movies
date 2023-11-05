using Microsoft.AspNetCore.Mvc;
using Movies.Services.Movies;
using Movies.Shared;
using Movies.Shared.Request;
using System.ComponentModel;

namespace Movies.API.Controllers
{
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet("Movies/{id}")]
        public ActionResult<ApiResponse<Movie>> Get([FromRoute]int id)
        {
            ApiResponse response = _moviesService.GetMovieById(id);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet("Movies")]
        public ActionResult<ApiResponse<IEnumerable<Movie>>> GetAll()
        {
            ApiResponse response = _moviesService.GetMovies();
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("Movies")]
        public ActionResult<ApiResponse> Post([FromBody]MoviePostPutRequest body)
        {
            ApiResponse response = _moviesService.AddMovie(body);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete("Movies/{id}")]
        public ActionResult<ApiResponse> Delete([FromRoute]int id)
        {
            ApiResponse response = _moviesService.DeleteMovie(id);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPut("Movies/{id}")]
        public ActionResult<ApiResponse> Put([FromRoute]int id, [FromBody]MoviePostPutRequest body)
        {
            ApiResponse response = _moviesService.UpdateMovie(id, body);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
