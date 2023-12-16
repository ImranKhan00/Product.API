using Microsoft.AspNetCore.Mvc;

using Product.API.Models.Request;

using Products.API.Respositories.Interfaces;

namespace Products.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {

    private readonly IProductRepository _productRepository;
    public ProductsController(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

    [HttpGet]
    //Get All Products
    public async Task<IActionResult> GetAllProducts()
    {
      var categories =  _productRepository.GetAll();
      //map model to DTO
      return Ok(categories.ToList());
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetProductById(int id)
    {
      //getting product by id
      var product =  _productRepository.Get(id);
      if (product is null)
      {
        return NotFound();
      }
      return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductRequest request)
    {
      //Convert DTO to domain
      var product = new Product.API.Models.Domain.Product
      {
        Name = request.Name,
      };
      product =  _productRepository.Add(product);
      return Ok(product);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id)
    {
      var deleteProduct = _productRepository.Delete(_productRepository.Get(id));
    
      return Ok(deleteProduct);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] int id, ProductRequest request)
    {
      //Convert DTO to domain
      var product = new Product.API.Models.Domain.Product
      {
        Id = id,
        Name = request.Name,
      };

      //Call Repository to Update Blogpost Domain Model
      var updateProduct =  _productRepository.Update(id, product);
      //check for null
      if (updateProduct == null)
      {
        return NotFound();
      }

      return Ok(updateProduct);
    }
  }
}
