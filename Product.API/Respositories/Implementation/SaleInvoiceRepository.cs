using Product.API.Models.Domain;
using Product.API.Respositories.Implementation;

using Products.API.Data;
using Products.API.Respositories.Interfaces;

namespace Products.API.Respositories.Implementation
{
  public class SaleInvoiceRepository : BaseRepository<SaleInvoice>, ISaleInvoiceRepository
  {
    private readonly ApplicationDbContext _context;
    public SaleInvoiceRepository(ApplicationDbContext context) : base(context)
    {
      _context = context;
    }
    public SaleInvoice Get(int id) => base.GetAll().FirstOrDefault(x => x.Id == id);
  }
}
