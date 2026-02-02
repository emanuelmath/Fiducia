using Fiducia.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiducia.Application.Validators
{
    public class LoanRequestValidator : AbstractValidator<LoanRequest>
    {
        public LoanRequestValidator()
        {
            RuleFor(x => x.ClientId)
                .NotEmpty().WithMessage("Client ID is required.")
                .NotNull().WithMessage("Client ID is required.");

            RuleFor(x => x.TermMonths)
                .GreaterThan(0).WithMessage("Term months must be greater than 0.")
                .LessThanOrEqualTo(120).WithMessage("Term months must be less than or equal to 120.");

            RuleFor(x => x.Amount)
                .GreaterThanOrEqualTo(100).WithMessage("Amount must be at least $100.")
                .LessThanOrEqualTo(100000).WithMessage("Amount must not exceed $100,000.");

            RuleFor(x => x.InterestRate)
                .GreaterThan(0).WithMessage("Interest rate must be greater than 0%.");

            RuleFor(x => x.TypeOfAmortization)
            .IsInEnum().WithMessage("Select a valid amortization system.");
        }
    }
} 
