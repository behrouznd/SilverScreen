using Entities.LinkModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Presentation.ModelBinders;
using Service.Contracts.Base;
using Shared.DataTransferObjects.Movies;
using Shared.RequestFeatures;
using System.Text.Json;

namespace Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/categories/{categoryId}/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public MoviesController(IServiceManager serviceManager) =>         
            this._service = serviceManager;
         

        [HttpGet(Name = "GetMoviesForCategory")]
        [HttpHead]
        [ServiceFilter(typeof(ValidationMediaTypeAttribute))]
        public async Task<IActionResult> GetMovies(Guid categoryId, [FromQuery] MovieParameters movieParameters)
        {
            var linkParams = new LinkParameters(movieParameters, HttpContext);

            var moviesPagedResult = await _service.movieService.GetMoviesAsync(categoryId, linkParams, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(moviesPagedResult.metaData));

            return moviesPagedResult.linkResponse.HasLinks ?
                Ok(moviesPagedResult.linkResponse.LinkedEntities) :
                Ok(moviesPagedResult.linkResponse.ShapedEntities);
        }

        [HttpGet("{id:guid}" , Name = "GetMovieForCategory")]
        public async Task<IActionResult> GetMovie(Guid categoryId, Guid id)
        {
            var movie = await _service.movieService.GetMovieByIdAsync(categoryId, id, trackChanges: false);
            return Ok(movie);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateMovieCollection(Guid id, [FromBody]IEnumerable<MovieForCreationDto> moviesCollection)
        {
            var result = await _service.movieService.CreateMovieCollectionAsync(id, moviesCollection);
            return CreatedAtRoute("MovieCollection", new { result.ids }, result.movies);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteMovieForCategory(Guid categoryId, Guid id)
        {
            await _service.movieService.DeleteMovieForCategoryAsync(categoryId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateMovieForCategory(Guid categoryId, Guid id, [FromBody] MovieForUpdateDto movie)
        {           
            await _service.movieService.UpdateMovieForCategoryAsync(categoryId, id, movie, catTrackChanges: false, movTrackChanges: true);
            return NoContent();
        }

        [HttpOptions]
        [Authorize(Roles = "Administrator")]
        public IActionResult GetMovieOptions()
        {
            Response.Headers.Add("Allow", "Get, Post, Put, Delete, Head");
            return Ok();
        }
    }
}
