using Contracts.Movies;
using Entities.Movies;
using Repository.Base;
using Repository.Context;

namespace Repository.Movies
{
    public class MovieLanguageRepository : RepositoryBase<MovieLanguage> , IMovieLanguageRepository
    {
        public MovieLanguageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
