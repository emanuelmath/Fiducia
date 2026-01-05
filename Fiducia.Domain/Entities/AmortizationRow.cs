using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiducia.Domain.Entities
{
    public class AmortizationRow
    {
        public int InstallmentNumber { get; set; } 
        public DateTime PaymentDate { get; set; }  
        public decimal MonthlyPayment { get; set; } 
        public decimal InterestPart { get; set; }   // i
        public decimal PrincipalPart { get; set; } // R
        public decimal RemainingBalance { get; set; } // P
    }

}
