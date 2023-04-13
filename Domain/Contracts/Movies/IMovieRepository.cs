using Entities.Movies;

namespace Contracts.Movies
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync(Guid categoryId, bool trackChanges);

        Task<Movie> GetMovieAsync(Guid categoryId , Guid id , bool trackChanges);

        void CreateMovieForCategory(Guid categoryId , Movie movie);

        Task<IEnumerable<Movie>> GetMoviesByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);

        void DeleteMovie(Movie movie);
    }
}
