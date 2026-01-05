using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiducia.Application.DTOs
{
    public class LoanRequest
    {
        public Guid ClientId { get; set; }
        public decimal Amount { get; set; }
        public int TermMonths { get; set; }
        public decimal InterestRate { get; set; }
    }
}
