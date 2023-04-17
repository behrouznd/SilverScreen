using Entities.LinkModel;
using Shared.DataTransferObjects.Movies;
using Shared.RequestFeatures;
using System.Dynamic;

namespace Service.Contracts.Movies
{
    public interface IMovieService
    {
        Task<(LinkResponse linkResponse, MetaData metaData)> GetMoviesAsync(Guid categoryId, 
            LinkParameters movieParameters, bool trackChanges);

        Task<MovieDto> GetMovieByIdAsync(Guid categoryId, Guid movieId, bool trackChanges);

        Task<MovieDto> CreateMovieForCategoryAsync(Guid categoryId, MovieForCreationDto movie, bool trackChanges);

        Task<IEnumerable<MovieDto>> GetMoviesByIdsAsync(IEnumerable<Guid> ids,bool trackChanges);

        Task<(IEnumerable<MovieDto> movies , string ids)> CreateMovieCollectionAsync(Guid categoryId, IEnumerable<MovieForCreationDto> movieCollection);

        Task DeleteMovieForCategoryAsync(Guid categoryId, Guid id , bool trackChanges);

        Task UpdateMovieForCategoryAsync(Guid categoryId, Guid id, MovieForUpdateDto movie, bool catTrackChanges, bool movTrackChanges);
    }
}
