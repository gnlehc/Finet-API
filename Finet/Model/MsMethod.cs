using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finet.Model
{
    [Table("MsMethod")]
    public class MsMethod
    {
        [Key]
        [Column("MethodID")]
        public int MethodID { get; set; }
        [Column("MethodName")]
        public string MethodName { get; set; }
        [Column("Stsrc")]
        public string? Stsrc { get; set; }
    }
}
