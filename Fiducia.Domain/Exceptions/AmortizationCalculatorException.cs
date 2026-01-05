using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiducia.Domain.Exceptions
{
    public class AmortizationCalculatorException : Exception
    {
        public AmortizationCalculatorException(string message) : base(message) 
        {
            
        }
    }
}
