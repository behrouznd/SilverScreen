using Shared.DataTransferObjects.Movies;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.Categories
{
    public record CategoryForCreationDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        [MaxLength(60 , ErrorMessage = "Maximum Length for the Name is 60 characters")]
        public string? Name { get; init; }
        public IEnumerable<MovieForCreationDto>? Movies { get; init; }
    }
}
