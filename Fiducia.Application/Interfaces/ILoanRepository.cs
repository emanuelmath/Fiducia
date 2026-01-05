using Fiducia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiducia.Application.Interfaces
{
    public interface ILoanRepository
    {
        Task AddAsync(Loan loan);
        Task<Loan?> GetByIdAsync(Guid Id);
    }
}
