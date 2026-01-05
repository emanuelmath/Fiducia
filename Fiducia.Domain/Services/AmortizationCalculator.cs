using Fiducia.Domain.Entities;
using Fiducia.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiducia.Domain.Services
{
    public class AmortizationCalculator 
    {
        public List<AmortizationRow> CalculateAmortization(Loan loan)
        {
            List<AmortizationRow> listAmortizationRows = new List<AmortizationRow>();

            decimal interestMonth = loan.InterestRate / 12;
            decimal monthCuote = (loan.Amount * (interestMonth / (1 - (1 / PowDecimalWithInt(1 + interestMonth, loan.TermMonths)))));
            decimal capitalInsolute = loan.Amount;
            DateTime dateOfPayment = loan.DisbursementDate ?? DateTime.Now;

            for (int i = 1; i <= loan.TermMonths; i++)
            {
                decimal interestPart = capitalInsolute * interestMonth;
                decimal principalPart = monthCuote - interestPart;
                decimal remainingBalance = capitalInsolute - principalPart;


                AmortizationRow currentAmortization = new AmortizationRow()
                {
                    InstallmentNumber = i,
                    PaymentDate = dateOfPayment.AddMonths(i), 
                    MonthlyPayment = monthCuote,
                    InterestPart = interestPart,
                    PrincipalPart = principalPart,
                    RemainingBalance = remainingBalance
                };

                listAmortizationRows.Add(currentAmortization);

                capitalInsolute = currentAmortization.RemainingBalance;
                
            }

            return listAmortizationRows;
        }

        private decimal PowDecimalWithInt(decimal numBase, int numExponent)
        {

            if (numExponent < 0) 
            {
                throw new AmortizationCalculatorException("Financial exponent cannot be negative in this context.");
            } 

            decimal numPowed = 1m;

            if (numExponent == 0)
            {
                return numPowed;
            }

            for (int i = 1; i <= numExponent; i++) 
            { 
                numPowed *= numBase;
            }

            return numPowed;
        }

    }
}
