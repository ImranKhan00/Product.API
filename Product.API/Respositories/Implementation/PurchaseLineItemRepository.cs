using Product.API.Models.Domain;
using Product.API.Respositories.Implementation;

using Products.API.Data;
using Products.API.Respositories.Interfaces;

namespace Products.API.Respositories.Implementation
{
  public class PurchaseLineItemRepository : BaseRepository<PurchaseLineItem>, IPurchaseLineItemRepository
  {
    private readonly ApplicationDbContext _context;
    public PurchaseLineItemRepository(ApplicationDbContext context) : base(context)
    {
      _context = context;
    }
    public PurchaseLineItem Get(int id) => base.GetAll().FirstOrDefault(x => x.Id == id);
  }
}
