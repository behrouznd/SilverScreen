using Contracts.Base;
using Contracts.Logger;
using Service.Contracts.Genres;

namespace Services.Genres
{
    internal sealed class GenreService : IGenreService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public GenreService(IRepositoryManager repositoryManager,
            ILoggerManager loggerManager)
        {
            this._repository = repositoryManager;
            this._logger = loggerManager;
        }
    }
}
