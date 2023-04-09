using Shared.DataTransferObjects.Categories;

namespace Shared.DataTransferObjects.Movies
{
    public record MovieDto 
    {
        public Guid Id { get; set; }
        public string? Title { get; set; } 
        public string? PersianTitle { get; set; } 
        public string? Slug { get; set; }
        public string? Description { get; set; }
        public int PulicationYear { get; set; }
        public int TimeDuration { get; set; }
 
        public string? CoverImage { get; set; }
 
        public string? BannerImage { get; set; }
 
        public Guid CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
    }
}
