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
        [ForeignKey("AccountID")]
        public int AccountID { get; set; }
        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        [Column("Title")]
        public string? Title { get; set; }
        [Column("Description")]
        public string? Description { get; set; }
        [Column("Time")]
        public DateTime Time { get; set; }
        [Column("Stsrc")]
        public string? Stsrc { get; set; }
    }
}
