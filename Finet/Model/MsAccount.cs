using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finet.Model
{
    [Table("MsAccount")]
    public class MsAccount
    {
        [Key]
        [Column("AccountID")]
        public int AccountId { get; set; }
        [Column("AccountName")]
        public string AccountName { get; set; }
        [Column("Stsrc")]
        public string? Stsrc { get; set; }
    }
}
