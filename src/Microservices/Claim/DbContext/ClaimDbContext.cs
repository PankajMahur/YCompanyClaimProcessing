using Microsoft.EntityFrameworkCore;
using System;
using Models = Claim.Models;
namespace Claim
{
    public class ClaimDbContext : DbContext
    {
        public ClaimDbContext(DbContextOptions<ClaimDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Claim>()
              .HasData(
               new Models.Claim {  Id = Guid.NewGuid(), 
                                        PolicyCustomerId = Guid.Parse("3D460AD8-B566-49EF-A1F6-E44BD5B641F5"),
                                            PolicyId = Guid.NewGuid(),
                                                RegisterDate = DateTime.Now,
                                                    Status = YCompany.Microservices.Enums.ClaimStatus.Registered
                                });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Models.Claim> Claims { get; set; }
    }
}
