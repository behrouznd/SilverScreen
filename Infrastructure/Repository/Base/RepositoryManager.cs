using Contracts.Base;
using Contracts.Categories;
using Contracts.Genres;
using Contracts.Languages;
using Contracts.Movies;
using Repository.Categories;
using Repository.Context;
using Repository.Genres;
using Repository.Languages;
using Repository.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IGenreRepository> _genreRepository;
        private readonly Lazy<ILanguageRepository> _languageRepository;
        private readonly Lazy<IMovieRepository> _movieRepository;
        private readonly Lazy<IMovieFileRepository> _movieFileRepository;
        private readonly Lazy<IMovieGenreRepository> _movieGenreRepository;
        private readonly Lazy<IMovieLanguageRepository> _movieLanguageRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(repositoryContext));
            _genreRepository = new Lazy<IGenreRepository>(() => new GenreRepository(repositoryContext));
            _languageRepository = new Lazy<ILanguageRepository>(() => new LanguageRepository(repositoryContext));
            _movieFileRepository = new Lazy<IMovieFileRepository>(() => new MovieFileRepository(repositoryContext));
            _movieRepository = new Lazy<IMovieRepository>(() => new MovieRepository(repositoryContext));
            _movieGenreRepository = new Lazy<IMovieGenreRepository>(() => new MovieGenreRepository(repositoryContext));
            _movieLanguageRepository = new Lazy<IMovieLanguageRepository>(() => new MovieLanguageRepository(repositoryContext));

        }
        public ICategoryRepository Category => _categoryRepository.Value;

        public IGenreRepository Genre => _genreRepository.Value;

        public ILanguageRepository Language => _languageRepository.Value;

        public IMovieRepository Movie => _movieRepository.Value;

        public IMovieFileRepository MovieFile => _movieFileRepository.Value;

        public IMovieGenreRepository MovieGenre => _movieGenreRepository.Value;

        public IMovieLanguageRepository MovieLanguage => _movieLanguageRepository.Value;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
