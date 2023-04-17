using Contracts.Base;
using Contracts.Movies;
using Entities.Base;
using Entities.LinkModel;
using Shared.DataTransferObjects.Movies;
using Microsoft.Net.Http.Headers;

namespace SilverScreen.Utility
{
    public class MovieLinks : IMovieLinks
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IDataShaper<MovieDto> _dataShaper;

        public MovieLinks(LinkGenerator linkGenerator, IDataShaper<MovieDto> dataShaper)
        {
            this._linkGenerator = linkGenerator;
            this._dataShaper = dataShaper;
        }
        public LinkResponse TryGenerateLinks(IEnumerable<MovieDto> movieDtos, string fields, Guid categoryId, HttpContext content)
        {
            var shapedMovie = ShapeData(movieDtos, fields);

            if (ShouldGenerateLinks(content))
                return ReturnLinkdedMovies(movieDtos, fields, categoryId, content, shapedMovie);
            return ReturnShapedMovies(shapedMovie);
        }

        private List<Entity> ShapeData(IEnumerable<MovieDto> movieDtos, string fields) =>
            _dataShaper.ShapeData(movieDtos, fields)
            .Select(x => x.Entity)
            .ToList();


        private bool ShouldGenerateLinks(HttpContext httpContext)
        {
            var mediaType = (MediaTypeHeaderValue)httpContext.Items["AcceptHeaderMediaType"];

            return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
        }

        private LinkResponse ReturnShapedMovies(List<Entity> shapedMovies) =>
            new LinkResponse { ShapedEntities = shapedMovies };


        private LinkResponse ReturnLinkdedMovies(IEnumerable<MovieDto> movieDtos, string fields, Guid categoryId,
            HttpContext httpContent, List<Entity> shapedMovies)
        {
            var movieDtoList= movieDtos.ToList();
            for (int index = 0; index < movieDtoList.Count(); index++)
            {
                var movieLinks = CreateLinksForMovie(httpContent, categoryId, movieDtoList[index].Id, fields);
                shapedMovies[index].Add("Links", movieLinks);
            }

            var movieCollection = new LinkCollectionWrapper<Entity>(shapedMovies);
            var linkedMovies = CreateLinksForMovie(httpContent, movieCollection);

            return new LinkResponse { HasLinks = true, LinkedEntities = linkedMovies };
        }

        private List<Link> CreateLinksForMovie(HttpContext httpContext, Guid categoryId, Guid Id, string fields = "")
        {
            var Links = new List<Link>()
            {
                new Link(_linkGenerator.GetUriByAction(httpContext,"GetMovieForCategory" , values: new {categoryId , Id , fields}),
                    "self",
                    "Get")

            };
            return Links;
        }

        private LinkCollectionWrapper<Entity> CreateLinksForMovie(HttpContext httpContext, LinkCollectionWrapper<Entity> movieWrapper)
        {
            movieWrapper.Links.Add(
                new Link(_linkGenerator.GetUriByAction(httpContext, "GetMoviesForCategory", values: new { }),
                    "self",
                    "Get"));
             
            return movieWrapper;
        }
    }
}
