using Product.API.Respositories.Implementation;

using Products.API.Data;
using Products.API.Respositories.Implementation;
using Products.API.Respositories.Interfaces;
using Products.API.Respositories.Interfaces;

namespace Product.API.Services
{
  public class cUnitOfWork: IDisposable
  {
    #region Private Fields
    #endregion
    ApplicationDbContext db;// =new ImsDbContext();
    public IUserRepository UserRepository { get; private set; }
    public ICategoryRepository CategoryRepository { get; private set; }
    public ICustomerRepository CustomerRepository { get; private set; }
    public IProductRepository ProductRepository { get; private set; }
    public IPurchaseInvoiceRepository PurchaseInvoiceRepository { get; private set; }
    public ISaleInvoiceRepository SaleInvoiceRepository { get; private set; }
    public ISellerRepository SellerRepository { get; private set; }
    public ISaleLineItemRepository SaleLineItemRepository { get; private set; }
    public IPurchaseLineItemRepository PurchaseLineItemRepository { get; private set; }
    public void Complete()
    {
      // get all changed entities
      db.SaveChanges();
    }

    public cUnitOfWork(ApplicationDbContext dbContext)
    {
      db = dbContext;
      UserRepository = new UserRepository(db);
      CategoryRepository = new CategoryRepository(db);
      CustomerRepository = new CustomerRepository(db);
      //CustomerSellerRepository = new cCustomerSellerRepository(db);
      ProductRepository = new ProductRepository(db);
      PurchaseInvoiceRepository = new PurchaseInvoiceRepository(db);
      //RouteRepository = new cRouteRepository(db);
      SaleInvoiceRepository = new SaleInvoiceRepository(db);
      SellerRepository = new SellerRepository(db);
      ////UserRoleRepository=new cUserRoleRepository(db);
      SaleLineItemRepository = new SaleLineItemRepository(db);
      PurchaseLineItemRepository = new PurchaseLineItemRepository(db);
    }

    public void Dispose()
    {
      db?.Dispose();
    }

    public void RollBack()
    {
      //db.RollBack();
    }
  
}
}
