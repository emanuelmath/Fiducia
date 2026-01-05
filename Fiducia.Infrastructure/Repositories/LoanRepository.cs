using Fiducia.Domain.Interfaces;
using Fiducia.Infrastructure.Persistence;
using Fiducia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace Fiducia.Infrastructure.Repositories
{
    public class LoanRepository(FiduciaDbContext dbContext) : ILoanRepository
    {
        public async Task AddAsync(Loan loan)
        {
            await dbContext.Loans.AddAsync(loan);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Loan?> GetByIdAsync(Guid id)
        {
            return await dbContext.Loans.FindAsync(id);
        }
    }
}
