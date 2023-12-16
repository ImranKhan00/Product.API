using Microsoft.EntityFrameworkCore;

using Product.API.Models.Domain;

using System.Runtime.ConstrainedExecution;


namespace Products.API.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Product.API.Models.Domain.Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }


    public new DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
    public DbSet<PurchaseLineItem> PurchaseLineItems { get; set; }
    public DbSet<SaleInvoice> SaleInvoices { get; set; }
    public DbSet<SaleLineItem> SaleLineItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Product.API.Models.Domain.Product>().Navigation<Category>(x=>x.Category).AutoInclude();
      modelBuilder.Entity<SaleLineItem>().Navigation<Product.API.Models.Domain.Product>(x=>x.Product).AutoInclude();
      modelBuilder.Entity<SaleInvoice>().Navigation(x=>x.Items).AutoInclude();

      base.OnModelCreating(modelBuilder);
    }
  }
}
