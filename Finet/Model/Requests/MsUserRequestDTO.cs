using System.ComponentModel.DataAnnotations;

namespace Finet.Model.Requests
{
    public class LoginRequestDTO
    {
        [Required] 
        public string? Email { get; set; }

        [Required] 
        public string? Password { get; set; }
    }
    public class RegisterRequestDTO
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
