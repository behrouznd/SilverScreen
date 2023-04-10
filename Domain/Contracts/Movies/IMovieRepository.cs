using Entities.Movies;

namespace Contracts.Movies
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetMovies(Guid categoryId, bool trackChanges);

        Movie GetMovie(Guid categoryId , Guid id , bool trackChanges);

        void CreateMovieForCategory(Guid categoryId , Movie movie);

        IEnumerable<Movie> GetMoviesByIds(IEnumerable<Guid> ids, bool trackChanges);

        void DeleteMovie(Movie movie);
    }
}
