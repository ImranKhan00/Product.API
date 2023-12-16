using Microsoft.EntityFrameworkCore;

using Product.API.Respositories.Implementation;

using Products.API.Data;
using Products.API.Models.DTO_s;
using Products.API.Respositories.Interfaces;

namespace Products.API.Respositories.Implementation
{
  public class ProductRepository : BaseRepository<Product.API.Models.Domain.Product>, IProductRepository
  {
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context):base(context)
    {
      _context = context;
    }
    public Product.API.Models.Domain.Product Get(int id) => base.GetAll().FirstOrDefault(x => x.Id == id);
    public async Task<Product.API.Models.Domain.Product> CreateAsync(Product.API.Models.Domain.Product product)
    {
      await _context.Products.AddAsync(product);
      await _context.SaveChangesAsync();
      return product;
    }

    public async Task<Product.API.Models.Domain.Product?> DeleteAsync(int id)
    {
      var existingProduct = await _context.Products.FirstOrDefaultAsync(b => b.Id == id);
      if (existingProduct != null)
      {
        _context.Products.Remove(existingProduct);
        await _context.SaveChangesAsync();
        return existingProduct;
      }
      return null;
    }

    public async Task<IEnumerable<Product.API.Models.Domain.Product>> GetAllAsync()
    {
      return await _context.Products.Include(x => x.Category).ToListAsync();
    }

    public async Task<Product.API.Models.Domain.Product?> GetByIdAsync(int id)
    {
      return await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Product.API.Models.Domain.Product?> UpdateAsync(Product.API.Models.Domain.Product product)
    {
      //finding the existing blogpost and include the categories too
      var existingProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
      //check for null
      if (existingProduct == null)
      {
        return null;
      }
      //Update Blogpost
      _context.Entry(existingProduct).CurrentValues.SetValues(product);
      await _context.SaveChangesAsync();
      return existingProduct;
    }
  }
}
