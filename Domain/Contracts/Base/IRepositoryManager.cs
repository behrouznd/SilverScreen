using Contracts.Categories;
using Contracts.Genres;
using Contracts.Languages;
using Contracts.Movies;

namespace Contracts.Base
{
    public interface IRepositoryManager
    {
        ICategoryRepository Category { get; }
        IGenreRepository Genre { get; }
        ILanguageRepository Language { get; }
        IMovieRepository Movie { get; }
        IMovieFileRepository MovieFile { get; }
        IMovieGenreRepository MovieGenre { get; }
        IMovieLanguageRepository MovieLanguage { get; }

        void Save();

    }
}
