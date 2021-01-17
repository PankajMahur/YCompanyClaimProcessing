using Identity.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Identity
{
    public class IdentityDBContext : DbContext
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PolicyCustomer>()
              .HasData(
               new PolicyCustomer { CustomerId = Guid.NewGuid(), FirstName = "Pankaj" },
               new PolicyCustomer { CustomerId=  Guid.NewGuid(), FirstName = "Pooja"  },
               new PolicyCustomer { CustomerId = Guid.NewGuid(), FirstName = "Neha"  });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PolicyCustomer> PolicyCustomers { get; set; }
    }
}
