using Fiducia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiducia.Application.DTOs
{
    public class LoanResult
    {
        public Guid LoanId { get; set; }
        public decimal ApprovedAmount { get; set; }
        public decimal MonthlyPayment { get; set; }
        public List<AmortizationRow> AmortizationSchedule { get; set; } = new();
    }
}
