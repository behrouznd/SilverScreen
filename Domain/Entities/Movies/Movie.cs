using Entities.Base;
using Entities.Categories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Movies
{
    public class Movie : BaseEntity
    {
        [Required(ErrorMessage = "Title is a required field")]
        [MaxLength(100)]
        public string? Title { get; set; }
        [MaxLength(100)]
        public string? PersianTitle { get; set; }
        [MaxLength(100)]
        public string? Slug { get; set; }
        public string? Description { get; set; }
        public int PulicationYear { get; set; }
        public int TimeDuration { get; set; }
        [MaxLength(255)]
        public string? CoverImage { get; set; }
        [MaxLength(255)]
        public string? BannerImage { get; set; }


        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public Category? Category  { get; set; }


        public ICollection<MovieGenre>? MovieGenres { get; set; }

        public ICollection<MovieFile>? MovieFiles { get; set; }

        public ICollection<MovieLanguage>? MoiveLanguages { get; set; }
    }
}
