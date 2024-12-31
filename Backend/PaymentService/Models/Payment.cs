using System.ComponentModel.DataAnnotations;

namespace PaymentService.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public DateTime PaymentDue { get; set; }
        public double PaymentAmount { get; set; }
        public string PaymentStatus { get; set; }
    }
}
