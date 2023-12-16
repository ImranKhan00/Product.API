using System.ComponentModel.DataAnnotations;

namespace Product.API.Models.Domain
{
  public class Seller
  {
        public int Id { get; set; }
        [MaxLength(20)]
    public string FirstName { get; set; }
    [MaxLength(20)]
    public string LastName { get; set; }

    public virtual IEnumerable<PurchaseInvoice> Invoices { get; set; }
  }
}
