namespace Product.API.Models.Request
{
  public class ProductRequest
  {
        public string Name { get; set; }
        public string Description { get; set; }
        public double SalePrice { get; set; }
        public double PurchasePrice { get; set; }
        public int CategoryId { get; set; }
    }
}
