using Product.API.Models.Domain;

namespace Product.API.Models
{
  public class SalesByCategory
  {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<SaleInvoice> Invoices { get; set; }

    public double TotalSale => Invoices?.Sum(x => x.NetAmount) ?? 0;
    }
}
