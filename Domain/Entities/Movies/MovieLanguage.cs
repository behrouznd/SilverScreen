using Entities.Base;
using Entities.Languages;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Movies
{
    public class MovieLanguage : BaseEntity
    {
        [ForeignKey(nameof(Movie))]
        public Guid MovieId { get; set; }
        public Movie? Movie { get; set; }

        [ForeignKey(nameof(Language))]
        public Guid LanguageId { get; set; }
        public Language? Language    { get; set; }
    }
}
