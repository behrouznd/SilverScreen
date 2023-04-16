using AutoMapper;
using Contracts.Base;
using Contracts.Logger;
using Entities.Categories;
using Entities.Exceptions;
using Entities.Movies;
using Service.Contracts.Movies;
using Shared.DataTransferObjects.Movies;
using Shared.RequestFeatures;
using System.Dynamic;

namespace Services.Movies
{
    internal sealed class MovieService : IMovieService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<MovieDto> _dataShaper;

        public MovieService(IRepositoryManager repositoryManager,
            ILoggerManager loggerManager,
            IMapper autoMapper,
            IDataShaper<MovieDto> dataShaper)
        {
            this._repository = repositoryManager;
            this._logger = loggerManager;
            this._mapper = autoMapper;
            this._dataShaper = dataShaper;
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
            await GetCategoryAndCheckIfItExists(categoryId, trackChanges);

            var movieEntity = _mapper.Map<Movie>(movie);
            _repository.Movie.CreateMovieForCategory(categoryId, movieEntity);
            await _repository.SaveAsync();

            return _mapper.Map<MovieDto>(movieEntity);
        }



        public async Task<MovieDto> GetMovieByIdAsync(Guid categoryId, Guid movieId, bool trackChanges)
        {
            await GetCategoryAndCheckIfItExists(categoryId, trackChanges);

            var movie = await GetMovieAndCheckIfItExists(categoryId, movieId, trackChanges);
 
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<(IEnumerable<ExpandoObject> movies, MetaData metaData)> GetMoviesAsync(Guid categoryId, MovieParameters movieParameters, bool trackChanges)
        {
            await GetCategoryAndCheckIfItExists(categoryId,trackChanges);

            var moviesWithMetaData = await _repository.Movie.GetMoviesAsync(categoryId, movieParameters, trackChanges);

            var moviesDto = _mapper.Map<IEnumerable<MovieDto>>(moviesWithMetaData);

            var shapedData = _dataShaper.ShapeData(moviesDto, movieParameters.Fields);

            return (movies: shapedData, metaData: moviesWithMetaData.MetaData);
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
            await GetCategoryAndCheckIfItExists(categoryId , trackChanges);
       
            var movie = await GetMovieAndCheckIfItExists(categoryId, id, trackChanges);

            _repository.Movie.DeleteMovie(movie);
            await _repository.SaveAsync();

        }

        public async Task UpdateMovieForCategoryAsync(Guid categoryId, Guid id, MovieForUpdateDto movie, bool catTrackChanges, bool movTrackChanges)
        {
            await GetCategoryAndCheckIfItExists(categoryId , catTrackChanges);
            
            var movieEntity = await GetMovieAndCheckIfItExists(categoryId , id, movTrackChanges);

            _mapper.Map(movie, movieEntity);
            await _repository.SaveAsync();
        }


        private async Task<Category> GetCategoryAndCheckIfItExists(Guid id, bool trackChanges)
        {
            var category = await _repository.Category.GetCategoryAsync(id, trackChanges);
            if (category is null)
                throw new CategoryNotFoundException(id);
            return category;
        }

        private async Task<Movie> GetMovieAndCheckIfItExists(Guid categoryId, Guid id, bool trackChanges)
        {
            var movieEntity = await _repository.Movie.GetMovieAsync(categoryId, id, trackChanges);
            if (movieEntity is null)
                throw new MovieNotFoundException(id);
            return movieEntity;
        }
    }
}
