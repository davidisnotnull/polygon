using System.ComponentModel.DataAnnotations;

namespace Polygon.App.Data.Entities
{
    /// <summary>
    /// Use this as the basis for all Entity objects
    /// </summary>
    public abstract class EntityBase
    {
        [Required, Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public DateTime Created { get; } = DateTime.Now;

        public DateTime? Modified { get; set; }
    }
}
