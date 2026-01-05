using Microsoft.EntityFrameworkCore;
using Fiducia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiducia.Infrastructure.Persistence
{
    public class FiduciaDbContext(DbContextOptions<FiduciaDbContext> options) : DbContext(options)
    {
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Loan>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2); 

            modelBuilder.Entity<Loan>()
                .Property(p => p.InterestRate)
                .HasPrecision(18, 6); 
        }
    }
}
