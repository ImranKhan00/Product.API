using Microsoft.EntityFrameworkCore;

using Products.API.Models.Domain;

namespace Products.API.Data
{
    public class ApplicationDbContext:DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

        public DbSet<Models.Domain.Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }




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
