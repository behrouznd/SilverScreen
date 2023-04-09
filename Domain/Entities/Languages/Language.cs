using Entities.Base;
using Entities.Movies;
using System.ComponentModel.DataAnnotations;

namespace Entities.Languages
{
    public class Language : BaseEntity
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(20)]
        public string? Name { get; set; }

        [MaxLength(255)]
        public string? Image { get; set; }

        public ICollection<MovieLanguage>?  MovieLanguages { get; set; }

    }
}
