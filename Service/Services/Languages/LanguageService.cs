using Contracts.Base;
using Contracts.Logger;
using Service.Contracts.Languages;

namespace Services.Languages
{
    internal sealed class LanguageService : ILanguageService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public LanguageService(IRepositoryManager repositoryManager,
            ILoggerManager loggerManager)
        {
            this._repository = repositoryManager;
            this._logger = loggerManager;
        }
    }
}
