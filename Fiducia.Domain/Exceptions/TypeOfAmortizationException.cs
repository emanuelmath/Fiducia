using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiducia.Domain.Exceptions
{
    public class TypeOfAmortizationException : Exception
    {
        public TypeOfAmortizationException(string message) : base(message) { }

        public static TypeOfAmortizationException NotImplemented(string typeName)
            => new($"The amortization system '{typeName}' exists in our records but is currently not implemented or out of service.");
        public static TypeOfAmortizationException NotFound(string typeName)
            => new($"The amortization system '{typeName}' does not exist in our system.");
    }
}
