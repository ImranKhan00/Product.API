namespace Product.API.Models.Domain
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

        //public ICollection<Category> Categories { get; set; }

        //Categories
        //public int CategoryId { get; set; }
        //public string CategoryName { get; set; }
    }
}
