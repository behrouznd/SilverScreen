using Shared.DataTransferObjects.Movies;

namespace Shared.DataTransferObjects.Categories
{
    public record CategoryForCreationDto
    {
        public string? Name { get; set; }
        public IEnumerable<MovieForCreationDto>? Movies { get; set; }
    }
}
