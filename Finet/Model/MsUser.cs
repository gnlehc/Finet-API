using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finet.Model
{
    [Table("MsUser")]
    public class MsUser
    {
        [Key]
        [Column("UserID")]
        public Guid UserID { get; set; }

        [Column("Username")]
        public string? Username { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Password")]
        public string? Password { get; set; }
    }
}
