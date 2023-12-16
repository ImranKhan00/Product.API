using Product.API.Models.Domain;
using Product.API.Respositories.Implementation;

using Products.API.Data;
using Products.API.Respositories.Interfaces;

namespace Products.API.Respositories.Implementation
{
  public class SellerRepository : BaseRepository<Seller>, ISellerRepository
  {
    private readonly ApplicationDbContext _context;
    public SellerRepository(ApplicationDbContext context) : base(context)
    {
      _context = context;
    }
    public Seller Get(int id) => base.GetAll().FirstOrDefault(x => x.Id == id);
  }
}
