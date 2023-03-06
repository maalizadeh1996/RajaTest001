using Microsoft.EntityFrameworkCore;

namespace TestCompanyRaja.Areas.Admin.Models.Domain
{
    public class TestCompanyRajaDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=RajaCompany;Trusted_Connection=True;TrustServerCertificate=True;");

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().Property(c => c.Address).IsRequired(false);
            modelBuilder.Entity<Customer>().Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .IsRequired(true);


            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Order>().Property(o =>o.Id )
                .ValueGeneratedOnAdd()
                .IsRequired(true);
            modelBuilder.Entity<Order>().HasOne(o => o.Customer).WithMany(o => o.orders).HasForeignKey(o => o.CustomerID);
            modelBuilder.Entity<Order>().HasOne(o => o.Product).WithMany(o => o.orders).HasForeignKey(o => o.ProductId);

        }
    }
}
