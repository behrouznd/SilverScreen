using Entities.Movies;
using Shared.RequestFeatures;

namespace Contracts.Movies
{
    public interface IMovieRepository
    {
        Task<PagedList<Movie>> GetMoviesAsync(Guid categoryId, MovieParameters movieParameters, bool trackChanges);

        Task<Movie> GetMovieAsync(Guid categoryId , Guid id , bool trackChanges);

        void CreateMovieForCategory(Guid categoryId , Movie movie);

        Task<IEnumerable<Movie>> GetMoviesByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);

        void DeleteMovie(Movie movie);
    }
}
