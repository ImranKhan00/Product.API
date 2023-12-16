using Product.API.Models.Domain;
using Product.API.Respositories.Implementation;

using Products.API.Data;
using Products.API.Respositories.Interfaces;

namespace Products.API.Respositories.Implementation
{
  public class PurchaseInvoiceRepository : BaseRepository<PurchaseInvoice>, IPurchaseInvoiceRepository
  {
    private readonly ApplicationDbContext _context;
    public PurchaseInvoiceRepository(ApplicationDbContext context) : base(context)
    {
      _context = context;
    }
    public PurchaseInvoice Get(int id) => base.GetAll().FirstOrDefault(x => x.Id == id);
  }
}
