using Contracts.Movies;
using Entities.Movies;
using Repository.Base;
using Repository.Context;

namespace Repository.Movies
{
    public class MovieGenreRepository : RepositoryBase<MovieGenre> , IMovieGenreRepository
    {
        public MovieGenreRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
