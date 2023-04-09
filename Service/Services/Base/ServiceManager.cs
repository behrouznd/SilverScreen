﻿using AutoMapper;
using Contracts.Base;
using Contracts.Logger;
using Service.Contracts.Base;
using Service.Contracts.Categories;
using Service.Contracts.Genres;
using Service.Contracts.Languages;
using Service.Contracts.Movies;
using Services.Categories;
using Services.Genres;
using Services.Languages;
using Services.Movies;

namespace Services.Base
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IGenreService> _genreService;
        private readonly Lazy<ILanguageService> _languageService;
        private readonly Lazy<IMovieService> _movieService;
        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerManager loggerManager,
            IMapper mapper)
        {
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager , loggerManager, mapper));
            _genreService = new Lazy<IGenreService>(() => new GenreService(repositoryManager, loggerManager));
            _languageService = new Lazy<ILanguageService>(()=> new LanguageService(repositoryManager, loggerManager ));
            _movieService = new Lazy<IMovieService>(() => new MovieService(repositoryManager, loggerManager, mapper));
        }

        public ICategoryService categoryService => _categoryService.Value;

        public IGenreService genreService => _genreService.Value;

        public ILanguageService languageService => _languageService.Value;

        public IMovieService movieService => _movieService.Value;
    }
}
