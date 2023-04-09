using Entities.Base;
using Entities.Movies;
using System.ComponentModel.DataAnnotations;

namespace Entities.Categories
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Name is a required field")]
        [MaxLength(60)]
        public string? Name { get; set; }

        public ICollection<Movie>? Movies  { get; set; }
    }
}
