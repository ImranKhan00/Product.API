using Product.API.Models.Domain;
using Product.API.Models.Request;

namespace Product.API.Services
{
  public class SellerService
  {

      private readonly cUnitOfWork unitOfWork;

      public SellerService(cUnitOfWork uof)
      {
        this.unitOfWork = uof;
      }

      public object? GetAll()
      {
        var getSeller = unitOfWork.SellerRepository.GetAll();
        return getSeller;
      }

      public object? GetById(int id)
      {
        var getSellerById = unitOfWork.UserRepository.Get(id);
        return getSellerById;
      }
  }
}
