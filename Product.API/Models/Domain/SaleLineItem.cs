using System.Reflection;

namespace Product.API.Models.Domain
{
  public class SaleLineItem
  {
    public int Id { get; set; }
    public SaleLineItem() { }


    /// <summary>
    /// average price of unit purchased
    /// </summary>
    public double PurchasePrice { get; set; }

    /// <summary>
    /// price of single unit sold at
    /// </summary>
    public double? SalePrice { get; set; }

    /// <summary>
    /// profit for single item
    /// </summary>
    public double NetProfit { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }




        public SaleInvoice SaleInvoice { get; set; }
    public int SaleInvoiceId { get; set; }

    //public SaleLineItemDto ToDto() => new SaleLineItemDto(this);
  }
}
