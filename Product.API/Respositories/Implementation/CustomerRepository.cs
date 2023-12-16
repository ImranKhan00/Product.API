using Product.API.Models.Domain;
using Product.API.Respositories.Implementation;

using Products.API.Data;
using Products.API.Respositories.Interfaces;

namespace Products.API.Respositories.Implementation
{
  public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
  {
    private readonly ApplicationDbContext _context;
    public CustomerRepository(ApplicationDbContext context) : base(context)
    {
      _context = context;
    }
    public Customer Get(int id) => base.GetAll().FirstOrDefault(x => x.Id == id);
  }
}
