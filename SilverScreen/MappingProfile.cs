using AutoMapper;
using Entities.Categories;
using Entities.Movies;
using Shared.DataTransferObjects.Categories;
using Shared.DataTransferObjects.Movies;

namespace SilverScreen
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryForCreationDto, Category>();

            CreateMap<Movie, MovieDto>();
            CreateMap<MovieForCreationDto, Movie>();
            CreateMap<MovieForUpdateDto, Movie>();
        }
    }
}
