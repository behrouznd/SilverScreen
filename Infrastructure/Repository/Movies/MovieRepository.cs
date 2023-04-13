using Contracts.Movies;
using Entities.Movies;
using Repository.Base;
using Repository.Context;

namespace Repository.Movies
{
    public class MovieRepository : RepositoryBase<Movie> , IMovieRepository
    {
        public MovieRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateMovieForCategory(Guid categoryId, Movie movie)
        {
            movie.CategoryId = categoryId;
            Create(movie);
        }



        public async Task<Movie> GetMovieAsync(Guid categoryId, Guid id, bool trackChanges) =>
            FindByCondition(m => m.CategoryId.Equals(categoryId) && m.Id.Equals(id), trackChanges)
                .SingleOrDefault();
         

        public async Task<IEnumerable<Movie>> GetMoviesAsync(Guid categoryId, bool trackChanges) =>
            FindByCondition( m => m.CategoryId.Equals(categoryId), trackChanges)
                .ToList();

        public async Task<IEnumerable<Movie>> GetMoviesByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(m=> ids.Contains(m.Id), trackChanges).ToList();

        public void DeleteMovie(Movie movie) => Delete(movie);
      
    }
}
