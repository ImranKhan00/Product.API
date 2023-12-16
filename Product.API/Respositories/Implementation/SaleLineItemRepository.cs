using Product.API.Models.Domain;
using Product.API.Respositories.Implementation;

using Products.API.Data;
using Products.API.Respositories.Interfaces;

namespace Products.API.Respositories.Implementation
{
  public class SaleLineItemRepository : BaseRepository<SaleLineItem>, ISaleLineItemRepository
  {
    private readonly ApplicationDbContext _context;
    public SaleLineItemRepository(ApplicationDbContext context) : base(context)
    {
      _context = context;
    }
    public SaleLineItem Get(int id) => base.GetAll().FirstOrDefault(x => x.Id == id);
  }
}
