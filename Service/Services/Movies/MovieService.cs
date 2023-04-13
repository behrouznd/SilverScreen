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

        public async Task<(IEnumerable<MovieDto> movies, string ids)> CreateMovieCollectionAsync(Guid categoryId, IEnumerable<MovieForCreationDto> movieCollection)
        {
            if (movieCollection is null)
                throw new MovieCollectionBadRequest();
            var moviesEntity = _mapper.Map<IEnumerable<Movie>>(movieCollection);
            foreach (var movie in moviesEntity)
            {
                _repository.Movie.CreateMovieForCategory(categoryId, movie);
            }
            await _repository.SaveAsync();

            var movieCollectionToReturn = _mapper.Map<IEnumerable<MovieDto>>(moviesEntity);
            var ids = string.Join("," , movieCollectionToReturn.Select( x => x.Id));

            return (movies : movieCollectionToReturn, ids : ids);
        }

        public async Task<MovieDto> CreateMovieForCategoryAsync(Guid categoryId, MovieForCreationDto movie, bool trackChanges)
        {
            var category = await _repository.Category.GetCategoryAsync(categoryId, trackChanges);
            if(category == null)
                throw new CategoryNotFoundException(categoryId);

            var movieEntity = _mapper.Map<Movie>(movie);
            _repository.Movie.CreateMovieForCategory(categoryId, movieEntity);
            await _repository.SaveAsync();

            return _mapper.Map<MovieDto>(movieEntity);
        }



        public async Task<MovieDto> GetMovieByIdAsync(Guid categoryId, Guid movieId, bool trackChanges)
        {
            var category = await _repository.Category.GetCategoryAsync(categoryId, trackChanges);
            if (category == null)
                throw new CategoryNotFoundException(categoryId);

            var movie = await _repository.Movie.GetMovieAsync(categoryId, movieId, trackChanges);
            if(movie == null)
                throw new MovieNotFoundException(movieId);

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesAsync(Guid categoryId, bool trackChanges)
        {
            var category = await _repository.Category.GetCategoryAsync(categoryId,trackChanges);
            if(category == null)
                throw new CategoryNotFoundException(categoryId);

            var movies = await _repository.Movie.GetMoviesAsync(categoryId, trackChanges);

            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids == null)
                throw new IdParametersBadRequestException();
            var movies = await _repository.Movie.GetMoviesByIdsAsync(ids, trackChanges);
            if(movies.Count() != ids.Count())
                throw new CollectionByIdsBadRequestException();
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }


        public async Task DeleteMovieForCategoryAsync(Guid categoryId, Guid id, bool trackChanges)
        {
            var category = await _repository.Category.GetCategoryAsync(categoryId , trackChanges);
            if (category is null)
                throw new CategoryNotFoundException(categoryId);
            var movie = await _repository.Movie.GetMovieAsync(categoryId, id, trackChanges);
            if(movie == null)
                throw new MovieNotFoundException(id);

            _repository.Movie.DeleteMovie(movie);
            await _repository.SaveAsync();

        }

        public async Task UpdateMovieForCategoryAsync(Guid categoryId, Guid id, MovieForUpdateDto movie, bool catTrackChanges, bool movTrackChanges)
        {
            var category = await _repository.Category.GetCategoryAsync(categoryId , catTrackChanges);
            if (category is null)
                throw new CategoryNotFoundException(categoryId);

            var movieEntity = await _repository.Movie.GetMovieAsync(categoryId , id, movTrackChanges);
            if (movieEntity is null)
                throw new MovieNotFoundException(id);

            _mapper.Map(movie, movieEntity);
            await _repository.SaveAsync();
        }
    }
}
