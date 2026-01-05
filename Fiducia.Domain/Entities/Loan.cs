using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiducia.Domain.Enums;

namespace Fiducia.Domain.Entities
{
    public class Loan
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public decimal Amount { get; set; } // Monto Solicitado. P
        public decimal InterestRate { get; set; } // Tasa De Interés. i
        public int TermMonths { get; set; } // Meses Para Pagar. n
        public LoanStatus Status { get; set; }
        public DateTime RequestDate { get; set; } 
        public DateTime? DisbursementDate { get; set; } 
        public DateTime? FinishedDate { get; set; } 
    }
}
