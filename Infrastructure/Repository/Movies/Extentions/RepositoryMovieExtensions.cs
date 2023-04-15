using Entities.Movies;
using Repository.Utility;
using System.Linq.Dynamic.Core;

namespace Repository.Movies.Extentions
{
    public static class RepositoryMovieExtensions
    {
        public static IQueryable<Movie> FilterMovies(this IQueryable<Movie> movies, int publicationYear) =>
            movies.Where(x => (publicationYear == 0 || x.PulicationYear == publicationYear));

        public static IQueryable<Movie> Search(this IQueryable<Movie> movies, string? searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return movies;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return movies.Where(x => x.Title.ToLower().Contains(lowerCaseTerm) || x.PersianTitle.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Movie> Sort(this IQueryable<Movie> movies, string? orderByQueryString)
        {
            if(string.IsNullOrWhiteSpace(orderByQueryString))
                return movies.OrderBy( x=> x.Title);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Movie>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return movies.OrderBy(x => x.Title);

            return movies.OrderBy(orderQuery);
        }
         
    }
}
