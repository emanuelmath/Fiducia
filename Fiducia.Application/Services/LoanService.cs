using Fiducia.Application.DTOs;
using Fiducia.Application.Interfaces;
using Fiducia.Domain.Entities;
using Fiducia.Domain.Enums;
using Fiducia.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiducia.Application.Services
{
    public class LoanService(ILoanRepository loanRepository, IAmortizationCalculator amortizationCalculator, IValidator<LoanRequest> validator) : ILoanService
    {
        public async Task<LoanResult> CreateLoanAsync(LoanRequest request)
        {
           await validator.ValidateAndThrowAsync(request);

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

            List<AmortizationRow> amortizationSchedule = amortizationCalculator.CalculateAmortization(currentLoan).ToList();

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

