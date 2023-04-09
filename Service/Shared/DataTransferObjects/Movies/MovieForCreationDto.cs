namespace Shared.DataTransferObjects.Movies
{
    public record MovieForCreationDto
    {
        public string? Title { get; set; }
        public string? PersianTitle { get; set; }
        public string? Slug { get; set; }
        public string? Description { get; set; }
        public int PulicationYear { get; set; }
        public int TimeDuration { get; set; }
        public string? CoverImage { get; set; }
        public string? BannerImage { get; set; }
    }
}
