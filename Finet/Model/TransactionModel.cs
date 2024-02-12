using System.ComponentModel.DataAnnotations;

namespace Finet.Model
{
    public class TransactionModel
    {
        [Required]
        public String title { get; set; }

        public String description { get; set; }

        [Required]
        public double price { get; set; }
        [Required]
        public DateTime time { get; set; }

    }
}
