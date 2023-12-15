using Microsoft.EntityFrameworkCore;

using Products.API.Data;
using Products.API.Models.Domain;
using Products.API.Models.DTO_s;
using Products.API.Respositories.Interfaces;

namespace Products.API.Respositories.Implementation
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

    public async Task<IEnumerable<Models.Domain.Product>> GetAllAsync()
    {
      return await _context.Products.Include(x => x.Categories).ToListAsync();
    }

    public async Task<Models.Domain.Product?> GetByIdAsync(int id)
    {
      return await _context.Products.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<ProductCategory>> GetTotalQuantitySoldByCategoryAsync()
    {

      return await _context.ProductCategories
           .Include(pc => pc.Products)
           .Select(pc => new ProductCategory
           {
             ProductCategoryId = pc.ProductCategoryId,
             CategoryName = pc.CategoryName,
             Products = pc.Products.Select(p => new Product
             {
               Id = p.Id,
               Name = p.Name,
               QuantitySold = p.QuantitySold
             }).ToList(),
             TotalSold = pc.Products.Sum(p => p.QuantitySold)
           })
           .ToListAsync();

    }

    public async  Task<List<CategoryTotalQuantitySoldDTO>> GetTotalQuantitySoldPerCategory()
    {
        var products =  _context.Products.ToList();
        var result = products
            .SelectMany(p => p.Categories, (product, category) => new { product, category })
            .GroupBy(pc => pc.category)
            .Select(group => new CategoryTotalQuantitySoldDTO
            {
              CategoryName = group.Key.CategoryName,
              TotalQuantitySold = group.Sum(pc => pc.product.QuantitySold)
            })
            .ToList();
        return result;
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
