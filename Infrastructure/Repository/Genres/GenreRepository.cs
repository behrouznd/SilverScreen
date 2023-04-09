using Contracts.Genres;
using Entities.Genres;
using Repository.Base;
using Repository.Context;

namespace Repository.Genres
{
    public class GenreRepository : RepositoryBase<Genre> , IGenreRepository
    {
        public GenreRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
