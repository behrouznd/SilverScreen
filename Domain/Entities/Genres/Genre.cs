using Entities.Base;
using Entities.Movies;
using System.ComponentModel.DataAnnotations;

namespace Entities.Genres
{
    public class Genre : BaseEntity
    {
        [Required(ErrorMessage = "Name is a required field")]
        [MaxLength(60)]
        public string? Name { get; set; }

        public ICollection<MovieGenre>? MovieGenres    { get; set; }
    }
}
