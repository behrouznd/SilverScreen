using Contracts.Movies;
using Entities.Movies;
using Repository.Base;
using Repository.Context;
using System.Linq;

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

        public Movie GetMovie(Guid categoryId, Guid id, bool trackChanges) =>
            FindByCondition(m => m.CategoryId.Equals(categoryId) && m.Id.Equals(id), trackChanges)
                .SingleOrDefault();
         

        public IEnumerable<Movie> GetMovies(Guid categoryId, bool trackChanges) =>
            FindByCondition( m => m.CategoryId.Equals(categoryId), trackChanges)
                .ToList();
       
    }
}
