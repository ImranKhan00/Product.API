using Microsoft.EntityFrameworkCore;

using Products.API.Data;
using Products.API.Models.Domain;
using Products.API.Respositories.Interfaces;

namespace Products.API.Respositories.Implementation
{
  public class CategoryRepository : ICategoryRepository
  {
    private readonly ApplicationDbContext _context;
    public CategoryRepository(ApplicationDbContext  context)
    {
      _context = context;
    }
    public async Task<Category> CreateAsync(Category category)
    {
      await _context.Categories.AddAsync(category);
      await _context.SaveChangesAsync();
      return category;
    }

    public async Task<Category?> DeleteAsync(int id)
    {
      var existingCategory = await _context.Categories.FirstOrDefaultAsync(b => b.Id == id);
      if (existingCategory != null)
      {
        _context.Categories.Remove(existingCategory);
        await _context.SaveChangesAsync();
        return existingCategory;
      }
      return null;
    }

    public async Task<IEnumerable<Category?>> GetAllAsync()
    {
      return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
      return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Category?> UpdateAsync(Category category)
    {
      //finding the existing blogpost and include the categories too
      var existingCategory= await _context.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
      //check for null
      if (existingCategory == null)
      {
        return null;
      }
      //Update Blogpost
      _context.Entry(existingCategory).CurrentValues.SetValues(category);
      await _context.SaveChangesAsync();
      return existingCategory;
    }
  }
}
