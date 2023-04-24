using Service.Contracts.Categories;
using Service.Contracts.Genres;
using Service.Contracts.Languages;
using Service.Contracts.Movies;
using Service.Contracts.Users;

namespace Service.Contracts.Base
{
    public interface IServiceManager
    {
        ICategoryService categoryService { get; }
        IGenreService genreService { get; }
        ILanguageService languageService { get; }
        IMovieService movieService { get; }

        IAuthenticationService authenticationService { get; }
    }
}
