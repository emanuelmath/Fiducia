using Microsoft.EntityFrameworkCore;
using Fiducia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiducia.Infrastructure.Persistence
{
    public class FiduciaDbContext : DbContext
    {
        public FiduciaDbContext(DbContextOptions<FiduciaDbContext> options) : base(options)
        {
            
        }
        public DbSet<Loan> Loans { get; set; }
    }
}
