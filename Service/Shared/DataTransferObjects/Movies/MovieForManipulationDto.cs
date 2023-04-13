using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.Movies
{
    public abstract record MovieForManipulationDto
    {
        [Required(ErrorMessage = "Title is a required field")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Title is 100 characters")]
        public string? Title { get; init; }
        [MaxLength(100, ErrorMessage = "Maximum length for the PersianTitle is 100 characters")]
        public string? PersianTitle { get; init; }
        [MaxLength(100, ErrorMessage = "Maximum length for the Slug is 100 characters")]
        public string? Slug { get; init; }
        public string? Description { get; init; }
        [Range(1000, int.MaxValue, ErrorMessage = "PublicationYear can't be lower than 1000")]
        public int PulicationYear { get; init; }
        [Range(1, int.MaxValue, ErrorMessage = "TimeDuration can't be lower than 1")]
        public int TimeDuration { get; init; }
        [MaxLength(255, ErrorMessage = "Maximum length for the CoverImage is 255 characters")]
        public string? CoverImage { get; init; }
        [MaxLength(255, ErrorMessage = "Maximum length for the BannerImage is 255 characters")]
        public string? BannerImage { get; init; }
    }
}
