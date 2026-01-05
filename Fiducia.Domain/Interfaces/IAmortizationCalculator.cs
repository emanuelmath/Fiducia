using Fiducia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiducia.Domain.Interfaces
{
    public interface IAmortizationCalculator
    {
        List<AmortizationRow> CalculateAmortization(Loan loan);
    }
}
