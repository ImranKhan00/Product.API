using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Products.API.Models.Domain;
using Products.API.Models.DTO_s;
using Products.API.Respositories.Interfaces;

namespace Products.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    public ProductController(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

    [HttpGet]
    //Get All Products
    public async Task<IActionResult> GetAllProducts()
    {
      var products = await _productRepository.GetAllAsync();
      //map model to DTO
      var response = new List<ProductDTO>();
      foreach (var product in products)
      {
        response.Add(new ProductDTO
        {
          Id = product.Id,
          Name = product.Name,
          Description = product.Description,
          Price = product.Price,
          Quantity = product.Quantity,
          Remarks = product.Remarks,
          Status = product.Status,
          IsSoldOut = product.IsSoldOut,
          Categories = product.Categories.Select(x => new CategoryDTO
          {
            Id = x.Id,
            CategoryName = x.CategoryName,
            Description = x.Description
          }).ToList()
        });
        ;
      }
      return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetProductById(int id)
    {
      //getting product by id
      var product = await _productRepository.GetByIdAsync(id);
      if (product is null)
      {
        return NotFound();
      }
      var response = new ProductDTO
      {
        Id = product.Id,
        Name = product.Name,
        Description = product.Description,
        Price = product.Price,
        Quantity = product.Quantity,
        Remarks = product.Remarks,
        Status = product.Status,
        IsSoldOut = product.IsSoldOut,
        Categories = product.Categories.Select(x => new CategoryDTO
        {
          Id = x.Id,
          CategoryName = x.CategoryName,
          Description = x.Description
        }).ToList()
      };
      return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestDTO request)
    {
      //Convert DTO to domain
      var product = new Products.API.Models.Domain.Product
      {
        Name = request.Name,
        Description = request.Description,
        Price = request.Price,
        Quantity = request.Quantity,
        Remarks = request.Remarks,
        Status = request.Status,
        IsSoldOut = request.IsSoldOut,
        //initialized the list of categories
        Categories = new List<Category>()
      };

      //Loop through all the Categories IDs and select t{he value that is present in db
      foreach(var categoryId in request.Categories)
      {
        //find existing
        var existingCategory = await _categoryRepository.GetByIdAsync(categoryId);
        if(existingCategory is not null)
        {
          product.Categories.Add(existingCategory);
        }
      }

      product = await _productRepository.CreateAsync(product);
      //Convert Domain to DTO
      var response = new ProductDTO
      {
        Id = product.Id,
        Name = product.Name,
        Description = product.Description,
        Price = product.Price,
        Quantity = product.Quantity,
        Remarks = product.Remarks,
        Status = product.Status,
        IsSoldOut = product.IsSoldOut,
        Categories = product.Categories.Select(x => new CategoryDTO
        {
          Id = x.Id,
          CategoryName = x.CategoryName,
          Description = x.Description
        }).ToList()
      };
      return Ok(response);

    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id)
    {
      var deleteProduct = await _productRepository.DeleteAsync(id);
      if (deleteProduct == null)
      {
        return NotFound();
      }
      //Convert Domain Model to DTO
      var response = new ProductDTO
      {
        Id = deleteProduct.Id,
        Name = deleteProduct.Name,
        Description = deleteProduct.Description,
        Price = deleteProduct.Price,
        Quantity = deleteProduct.Quantity,
        Remarks = deleteProduct.Remarks,
        Status = deleteProduct.Status,
        IsSoldOut = deleteProduct.IsSoldOut

      };
      return Ok(response);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] int id, UpdateProductRequestDto request)
    {
      //Convert DTO to domain
      var product = new Products.API.Models.Domain.Product
      {
        Id = id,
        Name = request.Name,
        Description = request.Description,
        Price = request.Price,
        Quantity = request.Quantity,
        Remarks = request.Remarks,
        Status = request.Status,
        IsSoldOut = request.IsSoldOut,
        Categories = new List<Category>()
      };


      //Iterating through request DTO
      foreach (var categoryId in request.Categories)
      {
        var existingCategory = await _categoryRepository.GetByIdAsync(categoryId);
        if (existingCategory != null)
        {
          product.Categories.Add(existingCategory);
        }
      }


      //Call Repository to Update Blogpost Domain Model
      var updateProduct = await _productRepository.UpdateAsync(product);
      //check for null
      if (updateProduct == null)
      {
        return NotFound();
      }

      //convert Domain Model to DTO
      var response = new ProductDTO
      {
        Id = product.Id,
        Name = product.Name,
        Description = product.Description,
        Price = product.Price,
        Quantity = product.Quantity,
        Remarks = product.Remarks,
        Status = product.Status,
        IsSoldOut = product.IsSoldOut,
        Categories = product.Categories.Select(x => new CategoryDTO
        {
          Id = x.Id,
          CategoryName = x.CategoryName,
          Description = x.Description
        }).ToList()
      };
      return Ok(response);
    }

    [HttpGet("total-quantity-sold-by-category")]
    public async Task<ActionResult<List<ProductCategory>>> GetTotalQuantitySoldByCategory()
    {
      var result = await _productRepository.GetTotalQuantitySoldByCategoryAsync();
      return Ok(result);
    }
    //[HttpGet("soldItems")]
    //public async Task<IActionResult> GetSoldItems()
    //{
    //  try
    //  {
    //    var allProducts = await _productRepository.GetAllAsync();

    //    // Use LINQ to filter only the sold items
    //    var soldItems = allProducts.Where(product => product.IsSoldOut);

    //    // You can map the sold items to DTOs here if needed
    //    // For simplicity, returning the entities directly in this example
    //    return Ok(soldItems);
    //  }
    //  catch (Exception ex)
    //  {
    //    // Log the exception or handle it appropriately
    //    return StatusCode(500, "Internal Server Error");
    //  }
    //}
  }
}
