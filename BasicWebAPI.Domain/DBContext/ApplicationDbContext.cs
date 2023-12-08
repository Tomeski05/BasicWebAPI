using BasicWebAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicWebAPI.Domain.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and other model-specific settings
            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Company)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CompanyId);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Country)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CountryId);
        }
    }
}
