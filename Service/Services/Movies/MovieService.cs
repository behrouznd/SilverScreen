using AutoMapper;
using Contracts.Base;
using Contracts.Logger;
using Entities.Exceptions;
using Entities.Movies;
using Service.Contracts.Movies;
using Shared.DataTransferObjects.Movies;

namespace Services.Movies
{
    internal sealed class MovieService : IMovieService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public MovieService(IRepositoryManager repositoryManager,
            ILoggerManager loggerManager,
            IMapper autoMapper)
        {
            this._repository = repositoryManager;
            this._logger = loggerManager;
            this._mapper = autoMapper;
        }

        public MovieDto CreateMovieForCategory(Guid categoryId, MovieForCreationDto movie, bool trackChanges)
        {
            var category = _repository.Category.GetCategory(categoryId, trackChanges);
            if(category == null)
                throw new CategoryNotFoundException(categoryId);

            var movieEntity = _mapper.Map<Movie>(movie);
            _repository.Movie.CreateMovieForCategory(categoryId, movieEntity);
            _repository.Save();

            return _mapper.Map<MovieDto>(movieEntity);
        }

        public MovieDto GetMovieById(Guid categoryId, Guid movieId, bool trackChanges)
        {
            var category = _repository.Category.GetCategory(categoryId, trackChanges);
            if (category == null)
                throw new CategoryNotFoundException(categoryId);

            var movie = _repository.Movie.GetMovie(categoryId, movieId, trackChanges);
            if(movie == null)
                throw new MovieNotFoundException(movieId);

            return _mapper.Map<MovieDto>(movie);
        }

        public IEnumerable<MovieDto> GetMovies(Guid categoryId, bool trackChanges)
        {
            var category = _repository.Category.GetCategory(categoryId,trackChanges);
            if(category == null)
                throw new CategoryNotFoundException(categoryId);

            var movies = _repository.Movie.GetMovies(categoryId, trackChanges);

            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }
    }
}
