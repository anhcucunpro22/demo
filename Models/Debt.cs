using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TH.Models
{
    public class Debt
    {
        [Key]
        public int DebtID { get; set; }

        public int? UserID { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public decimal? DebtAmount { get; set; }

        public string? PaymentMethod { get; set; }

        public string? Status { get; set; }

        public DateTime? DueDate { get; set; }

        [ForeignKey("UserID")]
        public Users? User { get; set; }
    }
}
