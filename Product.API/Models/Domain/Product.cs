namespace Products.API.Models.Domain
{
  public class Product
  {
    public int Id { get; set; }
    //productName
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Remarks { get; set; }
    public string Status { get; set; }
    public bool IsSoldOut { get; set; }
    //for new class
    public int QuantitySold { get; set; } // Assuming you have a field to track the quantity sold for each product
    public int ProductCategoryId { get; set; }
    public ProductCategory ProductCategory { get; set; }


    public ICollection<Category> Categories { get; set; }
  }
}
