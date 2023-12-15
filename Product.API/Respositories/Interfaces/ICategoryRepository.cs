﻿using Products.API.Models.Domain;

namespace Products.API.Respositories.Interfaces
{
  public interface ICategoryRepository
  {
    Task<Category> CreateAsync(Category category);
    Task<IEnumerable<Category?>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task<Category?> UpdateAsync(Category category);
    Task<Category?> DeleteAsync(int id);
  }
}
