using Contracts.Movies;
using Entities.Movies;
using Repository.Base;
using Repository.Context;

namespace Repository.Movies
{
    public class MovieFileRepository : RepositoryBase<MovieFile> , IMovieFileRepository
    {
        public MovieFileRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
