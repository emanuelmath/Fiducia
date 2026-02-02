using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiducia.Domain.Enums;

namespace Fiducia.Domain.Entities
{
    public class AmortizationRow
    {
        public Guid Id { get; set; }
        public Guid LoanId { get; set; }
        public Guid ClientId { get; set; }

        public int InstallmentNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal InterestPart { get; set; }   
        public decimal PrincipalPart { get; set; } 
        public decimal RemainingBalance { get; set; }

        public AmortizationRowStatus Status { get; set; } = AmortizationRowStatus.Simulated;
    }

}
