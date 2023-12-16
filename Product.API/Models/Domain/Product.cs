namespace Product.API.Models.Domain
{
  public class Product
  {
    public int Id { get; set; }
    //productName
    public string Name { get; set; }
    public string Description { get; set; }
    public double PurchasePrice { get; set; }
    public double SalePrice { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
  }
}
