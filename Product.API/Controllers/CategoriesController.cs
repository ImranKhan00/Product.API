using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PigeonPad.Services;

using Product.API.Models.Request;


namespace Categories.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoriesController : ControllerBase
  {

    CategoryService _Service;
    public CategoriesController(CategoryService service)
    {
      _Service = service;
    }

    [HttpGet]
    //Get All Categories
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
    public async Task<IActionResult> Create([FromBody] CategoryRequest request)
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
    public async Task<IActionResult> Update([FromRoute] int id, CategoryRequest request)
    {
      return Ok(_Service.Update(id, request));
    }
  }
}
