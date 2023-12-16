namespace Products.API.Models.Domain
{
  public class ProductCategory
  {
    public int ProductCategoryId { get; set; }
    public string CategoryName { get; set; }
    public List<Product.API.Models.Domain.Product> Products { get; set; }
    public int TotalSold { get; set; }
  }
}
