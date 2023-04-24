using AutoMapper;
using Entities.Categories;
using Entities.Movies;
using Entities.Users;
using Shared.DataTransferObjects.Categories;
using Shared.DataTransferObjects.Movies;
using Shared.DataTransferObjects.Users;

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

            CreateMap<UserForRegisterationDto, User>();

        }
    }
}
