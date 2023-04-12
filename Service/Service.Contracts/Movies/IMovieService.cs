using Shared.DataTransferObjects.Movies;

namespace Service.Contracts.Movies
{
    public interface IMovieService
    {
        IEnumerable<MovieDto> GetMovies(Guid categoryId, bool trackChanges);

        MovieDto GetMovieById(Guid categoryId, Guid movieId, bool trackChanges);

        MovieDto CreateMovieForCategory(Guid categoryId, MovieForCreationDto movie, bool trackChanges);

        IEnumerable<MovieDto> GetMoviesByIds(IEnumerable<Guid> ids,bool trackChanges);

        (IEnumerable<MovieDto> movies , string ids) CreateMovieCollection(Guid categoryId, IEnumerable<MovieForCreationDto> movieCollection);

        void DeleteMovieForCategory(Guid categoryId, Guid id , bool trackChanges);

        void UpdateMovieForCategory(Guid categoryId, Guid id, MovieForUpdateDto movie, bool catTrackChanges, bool movTrackChanges);
    }
}
