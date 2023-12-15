using Microsoft.EntityFrameworkCore;

using Product.API.Models.Domain;

namespace Product.API.Data
{
    public class ApplicationDbContext:DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

        public DbSet<Models.Domain.Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }




        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //  // Configure relationships, constraints, etc.
        //  modelBuilder.Entity<Models.Domain.Product>()
        //      .HasOne(p => p.Product.API.Models.Domain.Category)
        //      .WithMany(c => c.Products)
        //      .HasForeignKey(p => p.CategoryId);
        //}
    }
}
