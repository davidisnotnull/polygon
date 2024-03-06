using System.ComponentModel.DataAnnotations;

namespace Polygon.App.Data.Entities
{
    public class ApplicationUser : EntityBase
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
