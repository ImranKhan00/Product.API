namespace Product.API.Respositories.Interfaces
{
    public interface IProductRepository
  {
    Task<Models.Domain.Product> CreateAsync(Models.Domain.Product product);
    Task<IEnumerable<Models.Domain.Product?>> GetAllAsync();
    Task<Models.Domain.Product?> GetByIdAsync(int id);
    Task<Models.Domain.Product?> UpdateAsync(Models.Domain.Product product);
    Task<Models.Domain.Product?> DeleteAsync(int id);
    //Task<Models.Domain.Product?> GetSoldItems(bool soldItems);
  }
}
