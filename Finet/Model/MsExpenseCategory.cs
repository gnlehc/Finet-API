using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finet.Model
{
    [Table("MsExpenseCategory")]
    public class MsExpenseCategory
    {
        [Key]
        [Column("ECategoryID")]
        public int ECategoryID { get; set; }
        [Column("ECategoryName")]
        public string ECategoryName { get; set; }
        [Column("Stsrc")]
        public string? Stsrc { get; set;}
    }
}
