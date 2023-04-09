using Shared.DataTransferObjects.Movies;

namespace Service.Contracts.Movies
{
    public interface IMovieService
    {
        IEnumerable<MovieDto> GetMovies(Guid categoryId, bool trackChanges);

        MovieDto GetMovieById(Guid categoryId, Guid movieId, bool trackChanges);

        MovieDto CreateMovieForCategory(Guid categoryId, MovieForCreationDto movie, bool trackChanges);
    }
}
