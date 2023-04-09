using Contracts.Languages;
using Entities.Languages;
using Repository.Base;
using Repository.Context;

namespace Repository.Languages
{
    public class LanguageRepository : RepositoryBase<Language> , ILanguageRepository
    {
        public LanguageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
