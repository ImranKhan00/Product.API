namespace Product.API.Models.Domain
{
  public class PurchaseLineItem
  {
    public int Id { get; set; }
    /// <summary>
    /// purchase price of each unit in current purchase
    /// it is the actual purchase price after all discounts
    /// </summary>
    public double ActualPrice { get; set; }
    /// <summary>
    /// purchase price of item at the time of purchase
    /// it doesnot represent the actual price after discounts
    /// </summary>
    public double PurchasePrice { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int PurchaseInvoiceId { get; set; }
    public virtual PurchaseInvoice Invoice { get; set; }
  }
}
