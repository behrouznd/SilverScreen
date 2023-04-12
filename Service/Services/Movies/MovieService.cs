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

        public (IEnumerable<MovieDto> movies, string ids) CreateMovieCollection(Guid categoryId, IEnumerable<MovieForCreationDto> movieCollection)
        {
            if (movieCollection is null)
                throw new MovieCollectionBadRequest();
            var moviesEntity = _mapper.Map<IEnumerable<Movie>>(movieCollection);
            foreach (var movie in moviesEntity)
            {
                _repository.Movie.CreateMovieForCategory(categoryId, movie);
            }
            _repository.Save();

            var movieCollectionToReturn = _mapper.Map<IEnumerable<MovieDto>>(moviesEntity);
            var ids = string.Join("," , movieCollectionToReturn.Select( x => x.Id));

            return (movies : movieCollectionToReturn, ids : ids);
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

        public IEnumerable<MovieDto> GetMoviesByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids == null)
                throw new IdParametersBadRequestException();
            var movies = _repository.Movie.GetMoviesByIds(ids, trackChanges);
            if(movies.Count() != ids.Count())
                throw new CollectionByIdsBadRequestException();
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }


        public void DeleteMovieForCategory(Guid categoryId, Guid id, bool trackChanges)
        {
            var category = _repository.Category.GetCategory(categoryId , trackChanges);
            if (category is null)
                throw new CategoryNotFoundException(categoryId);
            var movie = _repository.Movie.GetMovie(categoryId, id, trackChanges);
            if(movie == null)
                throw new MovieNotFoundException(id);

            _repository.Movie.DeleteMovie(movie);
            _repository.Save();

        }

        public void UpdateMovieForCategory(Guid categoryId, Guid id, MovieForUpdateDto movie, bool catTrackChanges, bool movTrackChanges)
        {
            var category = _repository.Category.GetCategory(categoryId , catTrackChanges);
            if (category is null)
                throw new CategoryNotFoundException(categoryId);

            var movieEntity = _repository.Movie.GetMovie(categoryId , id, movTrackChanges);
            if (movieEntity is null)
                throw new MovieNotFoundException(id);

            _mapper.Map(movie, movieEntity);
            _repository.Save();
        }
    }
}
