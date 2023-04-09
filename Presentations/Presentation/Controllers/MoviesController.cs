using Microsoft.AspNetCore.Mvc;
using Service.Contracts.Base;
using Shared.DataTransferObjects.Movies;

namespace Presentation.Controllers
{

    [Route("api/categories/{categoryId}/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public MoviesController(IServiceManager serviceManager) =>         
            this._service = serviceManager;
         

        [HttpGet]
        public IActionResult GetMovies(Guid categoryId)
        {
            var movies = _service.movieService.GetMovies(categoryId, trackChanges: false);
            return Ok(movies);
        }

        [HttpGet("{id:guid}" , Name = "GetMovieForCategory")]
        public IActionResult GetMovie(Guid categoryId, Guid id)
        {
            var movie = _service.movieService.GetMovieById(categoryId, id, trackChanges: false);
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult CreateMovieForCategory(Guid id, [FromBody]MovieForCreationDto movie)
        {
            if (movie == null)
                return BadRequest("MovieForCreationDto object is null");

            var createdMovie = _service.movieService.CreateMovieForCategory(id, movie , trackChanges: false);
            return CreatedAtRoute("GetMovieForCategory", new { categoryId = id, id = createdMovie.Id }, createdMovie);

        }
    }
}
