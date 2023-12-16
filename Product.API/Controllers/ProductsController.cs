using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PigeonPad.Services;

using Product.API.Models.Domain;
using Product.API.Models.Request;

using Products.API.Models.DTO_s;
using Products.API.Respositories.Implementation;
using Products.API.Respositories.Interfaces;

namespace Products.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {

    ProductService _Service;
    public ProductsController(ProductService service)
    {
      _Service = service;
    }

    [HttpGet]
    //Get All Products
    public async Task<IActionResult> GetAll()
    {
      return Ok(_Service.GetAll());
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      return Ok(_Service.GetById(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductRequest request)
    {
      return Ok(_Service.Add(request));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      return Ok(_Service.Delete(id));
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, ProductRequest request)
    {
      return Ok(_Service.Update(id, request));
    }
  }
}
