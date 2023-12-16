using Product.API.Models.Domain;
using Product.API.Models.Request;

namespace Product.API.Services
{
  public class CustomerService
  {

      private readonly cUnitOfWork unitOfWork;

      public CustomerService(cUnitOfWork unitOfWork)
      {
        this.unitOfWork = unitOfWork;
      }

      public object? GetAll()
      {
        var getSeller = unitOfWork.CustomerRepository.GetAll();
        return getSeller;
      }

      public object? GetById(int id)
      {
        var getSellerById = unitOfWork.CustomerRepository.Get(id);
        return getSellerById;
      }

}
}
