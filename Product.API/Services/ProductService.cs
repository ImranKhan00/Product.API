

using Product.API.Models.Domain;
using Product.API.Models.Request;
using Product.API.Services;


namespace PigeonPad.Services
{
  public class ProductService
  {
    private readonly cUnitOfWork unitOfWork;

    public ProductService(cUnitOfWork unitOfWork)
    {
      this.unitOfWork = unitOfWork;
    }

    public Product.API.Models.Domain.Product Add(ProductRequest request)
    {
      var newCategory = new Product.API.Models.Domain.Product
      {
        Name = request.Name,
        Description = request.Description,
        SalePrice = request.SalePrice,
        PurchasePrice = request.PurchasePrice,
        CategoryId = request.CategoryId,
      };
      unitOfWork.ProductRepository.Add(newCategory);
      unitOfWork.Complete();
      return newCategory;
    }

    public object? GetAll()
    {
      var getAllProducts = unitOfWork.ProductRepository.GetAll();
      return getAllProducts;
    }

    public object? GetById(int id)
    {
      var getProductById = unitOfWork.ProductRepository.Get(id);
      return getProductById;
    }

    public Product.API.Models.Domain.Product Update(int id, ProductRequest request)
    {
      var product = unitOfWork.ProductRepository.Get(id);
      product.Name = request.Name;
      product.SalePrice= request.SalePrice;
      product.PurchasePrice = request.PurchasePrice;
      product.CategoryId = request.CategoryId;
      unitOfWork.ProductRepository.Update(id,product);
      unitOfWork.Complete();
      return product;
    }

    public object? Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}