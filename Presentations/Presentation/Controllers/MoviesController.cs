using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Presentation.ModelBinders;
using Service.Contracts.Base;
using Shared.DataTransferObjects.Movies;
using Shared.RequestFeatures;
using System.Text.Json;

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
        public async Task<IActionResult> GetMovies(Guid categoryId, [FromQuery] MovieParameters movieParameters)
        {
            var moviesPagesResult = await _service.movieService.GetMoviesAsync(categoryId, movieParameters , trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(moviesPagesResult.metaData));

            return Ok(moviesPagesResult.movies);
        }

        [HttpGet("{id:guid}" , Name = "GetMovieForCategory")]
        public async Task<IActionResult> GetMovie(Guid categoryId, Guid id)
        {
            var movie = await _service.movieService.GetMovieByIdAsync(categoryId, id, trackChanges: false);
            return Ok(movie);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateMovieForCategory(Guid id, [FromBody]MovieForCreationDto movie)
        {            
            var createdMovie = await _service.movieService.CreateMovieForCategoryAsync(id, movie, trackChanges: false);
            return CreatedAtRoute("GetMovieForCategory", new { categoryId = id, id = createdMovie.Id }, createdMovie);
        }

        [HttpGet("collection/({ids})", Name = "MovieCollection")]
        public async Task<IActionResult> GetMovieCollection([ModelBinder(binderType: typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var movies = await _service.movieService.GetMoviesByIdsAsync(ids, trackChanges: false);
            return Ok(movies);
        }


        [HttpPost("collection")]
        [ServiceFilter(typeof (ValidationFilterAttribute))]
        public async Task<IActionResult> CreateMovieCollection(Guid id, [FromBody]IEnumerable<MovieForCreationDto> moviesCollection)
        {
            var result = await _service.movieService.CreateMovieCollectionAsync(id, moviesCollection);

            return CreatedAtRoute("MovieCollection", new { result.ids }, result.movies);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteMovieForCategory(Guid categoryId, Guid id)
        {
            await _service.movieService.DeleteMovieForCategoryAsync(categoryId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateMovieForCategory(Guid categoryId, Guid id, [FromBody] MovieForUpdateDto movie)
        {           
             await _service.movieService.UpdateMovieForCategoryAsync(categoryId, id, movie, catTrackChanges: false, movTrackChanges: true);

            return NoContent();
        }
    }
}
