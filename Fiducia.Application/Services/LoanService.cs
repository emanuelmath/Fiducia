using Fiducia.Application.DTOs;
using Fiducia.Application.Interfaces;
using Fiducia.Domain.Entities;
using Fiducia.Domain.Enums;
using Fiducia.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiducia.Application.Services
{
    public class LoanService(ILoanRepository loanRepository) : ILoanService
    {
        public async Task<LoanResult> CreateLoanAsync(LoanRequest request)
        {
            if (request.Amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");
            if (request.TermMonths <= 0)
                throw new ArgumentException("Term must be greater than zero.");

            Loan currentLoan = new()
            {
                Id = Guid.NewGuid(),
                ClientId = request.ClientId,
                Amount = request.Amount,
                InterestRate = request.InterestRate,
                TermMonths = request.TermMonths,
                Status = LoanStatus.Pending,
                RequestDate = DateTime.Now,
                DisbursementDate = null,
                FinishedDate = null
            };

            var calculator = new AmortizationCalculator();
            List<AmortizationRow> amortizationSchedule = calculator.CalculateAmortization(currentLoan);

            await loanRepository.AddAsync(currentLoan);

            return new LoanResult 
            {
                LoanId = currentLoan.Id,
                AmortizationSchedule = amortizationSchedule,
                MonthlyPayment = amortizationSchedule[0].MonthlyPayment,
                ApprovedAmount= currentLoan.Amount
            };
        }
    }
}

