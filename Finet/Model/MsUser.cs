using System.ComponentModel.DataAnnotations;

namespace Finet.Model
{
    public class MsUser
    {
        [Key] [Required]
        public Guid UserID { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]  
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
