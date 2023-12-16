using Product.API.Models.Domain;
using Product.API.Models.Request;

namespace Product.API.Services
{
  public class UserService
  {

      private readonly cUnitOfWork unitOfWork;

      public UserService(cUnitOfWork unitOfWork)
      {
        this.unitOfWork = unitOfWork;
      }

      public object? GetAll()
      {
        var getSeller = unitOfWork.UserRepository.GetAll();
        return getSeller;
      }

      public object? GetById(int id)
      {
        var getSellerById = unitOfWork.UserRepository.Get(id);
        return getSellerById;
      }

}
}
