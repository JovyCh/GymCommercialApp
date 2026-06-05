using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.Domain
{
    public class PaymentLog
    {
        public Guid Id { get; set; }
        public Guid MemberId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public string PaymentStatus { get; set; } = "Success";
        public string? ExternalTransactionId { get; set; }
    }
}
