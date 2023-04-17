using Entities.LinkModel;
using Microsoft.AspNetCore.Http;
using Shared.DataTransferObjects.Movies;


namespace Contracts.Movies
{
    public interface IMovieLinks
    {
        LinkResponse TryGenerateLinks(IEnumerable<MovieDto> movieDtos, string fields, Guid categoryId, HttpContext content);
    }
}
