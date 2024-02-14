using System.ComponentModel.DataAnnotations;

namespace Finet.Model
{
    public class TransactionModel
    {
        [Required]
        public string? Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime Time { get; set; }

    }
}
