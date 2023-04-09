using Entities.Base;
using Entities.Genres;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Movies
{
    public class MovieGenre : BaseEntity
    {
        [ForeignKey(nameof(Movie))]
        public Guid MovieId { get; set; }
        public Movie? Movie { get; set; }

        [ForeignKey(nameof(Genre))]
        public Guid GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
