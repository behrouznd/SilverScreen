using Microsoft.AspNetCore.Mvc;
using Presentation.ModelBinders;
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

            var createdMovie = _service.movieService.CreateMovieForCategory(id, movie, trackChanges: false);
            return CreatedAtRoute("GetMovieForCategory", new { categoryId = id, id = createdMovie.Id }, createdMovie);
        }

        [HttpGet("collection/({ids})", Name = "MovieCollection")]
        public IActionResult GetMovieCollection([ModelBinder(binderType: typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var movies = _service.movieService.GetMoviesByIds(ids, trackChanges: false);
            return Ok(movies);
        }


        [HttpPost("collection")]
        public IActionResult CreateMovieCollection(Guid id, [FromBody]IEnumerable<MovieForCreationDto> moviesCollection)
        {
            var result = _service.movieService.CreateMovieCollection(id, moviesCollection);

            return CreatedAtRoute("MovieCollection", new { result.ids }, result.movies);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteMovieForCategory(Guid categoryId, Guid id)
        {
            _service.movieService.DeleteMovieForCategory(categoryId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateMovieForCategory(Guid categoryId, Guid id, [FromBody] MovieForUpdateDto movie)
        {
            if (movie is null)
                return BadRequest("MovieForUpdateDto object is null");

            _service.movieService.UpdateMovieForCategory(categoryId, id, movie, catTrackChanges: false, movTrackChanges: true);

            return NoContent();
        }
    }
}
