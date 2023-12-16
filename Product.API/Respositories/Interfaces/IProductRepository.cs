using Repositories;

namespace Products.API.Respositories.Interfaces
{
  public interface IProductRepository:IRepository<Product.API.Models.Domain.Product>
  {
    //Task<Models.Domain.Product> CreateAsync(Models.Domain.Product product);
    //Task<IEnumerable<Models.Domain.Product>> GetAllAsync();
    //Task<Models.Domain.Product?> GetByIdAsync(int id);
    //Task<Models.Domain.Product?> UpdateAsync(Models.Domain.Product product);
    //Task<Models.Domain.Product?> DeleteAsync(int id);
    //Task<Models.Domain.Product?> GetSoldItems(bool soldItems);
    //Task<List<CategoryTotalQuantitySoldDTO>> GetTotalQuantitySoldPerCategory();

    //Task<List<ProductCategory>> GetTotalQuantitySoldByCategoryAsync();

  }
}
