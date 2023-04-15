using Contracts.Movies;
using Entities.Movies;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Context;
using Shared.RequestFeatures;

namespace Repository.Movies
{
    public class MovieRepository : RepositoryBase<Movie> , IMovieRepository
    {
        public MovieRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateMovieForCategory(Guid categoryId, Movie movie)
        {
            movie.CategoryId = categoryId;
            Create(movie);
        }



        public async Task<Movie> GetMovieAsync(Guid categoryId, Guid id, bool trackChanges) =>
            await FindByCondition(m => m.CategoryId.Equals(categoryId) && m.Id.Equals(id), trackChanges)
                .SingleOrDefaultAsync();


        public async Task<PagedList<Movie>> GetMoviesAsync(Guid categoryId, MovieParameters movieParameters, bool trackChanges)
        {
            var movies = await FindByCondition(m => m.CategoryId.Equals(categoryId) &&
                (movieParameters.PublicationYear == 0 || m.PulicationYear == movieParameters.PublicationYear) &&
                (string.IsNullOrEmpty(movieParameters.Title) || m.Title.Contains(movieParameters.Title))
                , trackChanges)
                .Skip((movieParameters.PageNumber - 1) * movieParameters.PageSize)
                .Take(movieParameters.PageSize)
                .ToListAsync();

            var count = await FindByCondition(m => m.CategoryId.Equals(categoryId), trackChanges).CountAsync();

            return new PagedList<Movie>(movies, count, movieParameters.PageNumber, movieParameters.PageSize);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(m=> ids.Contains(m.Id), trackChanges).ToListAsync();

        public void DeleteMovie(Movie movie) => Delete(movie);
      
    }
}
