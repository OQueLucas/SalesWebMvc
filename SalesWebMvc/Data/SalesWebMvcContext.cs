using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Models
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext (DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SalesRecord>()
                .HasOne(e => e.Seller)
                .WithMany(e => e.Sales)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Seller>()
                .HasOne(e => e.Department)
                .WithMany(e => e.Sellers)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
