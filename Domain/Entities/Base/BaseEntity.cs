using System.ComponentModel.DataAnnotations;

namespace Entities.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
