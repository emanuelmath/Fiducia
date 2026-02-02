using Fiducia.Domain.Entities;
using Fiducia.Domain.Services;
using Fiducia.Domain.Enums;
using Xunit;

namespace Fiducia.Tests
{
    public class FrenchAmortizationCalculatorTests
    {
        [Fact]
        public void FrenchCalculateAmortization_ShouldReturnValidSchedule_ForStandardLoan()
        {
            // Values for the test. 
            const int PAYMENT_MONTH = 1;
            const decimal VALUE_MONTH = 4400.59m;
            const decimal INTEREST = 395.83m;
            const decimal AMORTIZATION = 4004.76m;
            const decimal BALANCE = 20995.24m;

            // Arrange.
            Loan loan = new Loan() 
            {
                Id = Guid.NewGuid(),
                ClientId = Guid.NewGuid(),
                Amount = 25000,
                InterestRate = 0.19m, //19%
                TermMonths = 6,
                Status = LoanStatus.Disbursed,
                DisbursementDate = DateTime.Now,
                RequestDate = DateTime.Now,
                FinishedDate = DateTime.Now.AddMonths(6),
            };

            // Service.
            var calculator = new FrenchAmortizationCalculator();

            // Act.
            var result = calculator.CalculateAmortization(loan).ToList();

            // Asserts:

            // List not empty.
            Assert.NotEmpty(result);

            // Verify values.
            Assert.Equal(PAYMENT_MONTH, result[0].InstallmentNumber);
            Assert.Equal(VALUE_MONTH, result[0].MonthlyPayment, 2);
            Assert.Equal(INTEREST, result[0].InterestPart, 2);
            Assert.Equal(AMORTIZATION, result[0].PrincipalPart, 2);
            Assert.Equal(BALANCE, result[0].RemainingBalance, 2);
        }
    }
}