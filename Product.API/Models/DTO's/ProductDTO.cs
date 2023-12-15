namespace Products.API.Models.DTO_s
{
  public class ProductDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Remarks { get; set; }
    public string Status { get; set; }
    public bool IsSoldOut { get; set; }
    public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
  }
}
