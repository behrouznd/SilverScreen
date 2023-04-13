﻿using Shared.DataTransferObjects.Movies;

namespace Service.Contracts.Movies
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetMoviesAsync(Guid categoryId, bool trackChanges);

        Task<MovieDto> GetMovieByIdAsync(Guid categoryId, Guid movieId, bool trackChanges);

        Task<MovieDto> CreateMovieForCategoryAsync(Guid categoryId, MovieForCreationDto movie, bool trackChanges);

        Task<IEnumerable<MovieDto>> GetMoviesByIdsAsync(IEnumerable<Guid> ids,bool trackChanges);

        Task<(IEnumerable<MovieDto> movies , string ids)> CreateMovieCollectionAsync(Guid categoryId, IEnumerable<MovieForCreationDto> movieCollection);

        Task DeleteMovieForCategoryAsync(Guid categoryId, Guid id , bool trackChanges);

        Task UpdateMovieForCategoryAsync(Guid categoryId, Guid id, MovieForUpdateDto movie, bool catTrackChanges, bool movTrackChanges);
    }
}
