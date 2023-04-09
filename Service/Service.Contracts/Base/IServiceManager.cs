using Service.Contracts.Categories;
using Service.Contracts.Genres;
using Service.Contracts.Languages;
using Service.Contracts.Movies;

namespace Service.Contracts.Base
{
    public interface IServiceManager
    {
        ICategoryService categoryService { get; }
        IGenreService genreService { get; }
        ILanguageService languageService { get; }
        IMovieService movieService { get; }
    }
}
