using Fiducia.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiducia.Application.Interfaces
{
    public interface ILoanService
    {
       Task<LoanResult> CreateLoanAsync(LoanRequest request);
    }
}
