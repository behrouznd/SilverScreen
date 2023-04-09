using Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Movies
{
    public class MovieFile : BaseEntity
    {
        public string? Title { get; set; }

        public string? Season { get; set; }
        public string? Chapter { get; set; }

        public string? FilePath { get; set; }

        public int Order { get; set; }

        public int AccessLevel { get; set; }

        [ForeignKey(nameof(MovieLanguage))]
        public Guid MovieLanguageId { get; set; }
        public MovieLanguage? MovieLanguage { get; set; }

      

    }
}
