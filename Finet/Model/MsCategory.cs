using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finet.Model
{
    [Table("MsCategory")]
    public class MsCategory
    {
        [Key]
        [Column("CategoryID")]
        public int CategoryID { get; set; }
        [Column("CategoryName")]
        public string CategoryName { get; set; }
        [Column("Stsrc")]
        public string? Stsrc { get; set;}
    }
}
