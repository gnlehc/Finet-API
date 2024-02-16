using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finet.Model
{
    [Table("TrExpense")]
    public class TrExpense
    {
        [Key]
        [Column("ExpenseID")]
        public Guid ExpenseID { get; set; }
        [ForeignKey("MethodID")]
        public int MethodID { get; set; }
        [ForeignKey("ECategoryID")]
        public int ECategoryID { get; set; }
        [Column("Title")]
        public string? Title { get; set; }
        [Column("Description")]
        public string? Description { get; set; }
        [Column("Amount")]
        public int Amount { get; set;}
        [Column("Time")]
        public DateTime Time { get; set; }
        [Column("Stsrc")]
        public string? Stsrc { get; set; }
    }
}
