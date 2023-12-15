using Microsoft.EntityFrameworkCore;

using Product.API.Data;
using Product.API.Respositories.Interfaces;

namespace Product.API.Respositories.Implementation
{
  public class ProductRepository : IProductRepository
  {
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<Models.Domain.Product> CreateAsync(Models.Domain.Product product)
    {
      await _context.Products.AddAsync(product);
      await _context.SaveChangesAsync();
      return product;
    }

    public async Task<Models.Domain.Product?> DeleteAsync(int id)
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

    public async Task<IEnumerable<Models.Domain.Product?>> GetAllAsync()
    {
      return await _context.Products.ToListAsync();
    }

    public async Task<Models.Domain.Product?> GetByIdAsync(int id)
    {
      return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    //public IEnumerable<Models.Domain.Product> GetSoldItems(IEnumerable<Models.Domain.Product> products)
    //{
    //  // Use LINQ to filter only the sold items
    //  var soldItems = products.Where(product => product.IsSoldOut);

    //  return soldItems;
    //}

    public async Task<Models.Domain.Product?> UpdateAsync(Models.Domain.Product product)
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
