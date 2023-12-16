using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Product.API.Models.Domain;

using Products.API.Models.DTO_s;
using Products.API.Respositories.Implementation;
using Products.API.Respositories.Interfaces;

namespace Products.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoriesController : ControllerBase
  {

    private readonly ICategoryRepository _categoryRepository;
    public CategoriesController(ICategoryRepository categoryRepository)
    {
      _categoryRepository = categoryRepository;
    }

    [HttpGet]
    //Get All Categories
    public async Task<IActionResult> GetAllCategories()
    {
      var categories =  _categoryRepository.GetAll();
      //map model to DTO
      return Ok(categories.ToList());
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
      //getting category by id
      var category =  _categoryRepository.Get(id);
      if (category is null)
      {
        return NotFound();
      }
      return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO request)
    {
      //Convert DTO to domain
      var category = new Category
      {
        Name = request.CategoryName,
      };
      category =  _categoryRepository.Add(category);
      return Ok(category);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] int id)
    {
      var deleteCategory = _categoryRepository.Delete(_categoryRepository.Get(id));
    
      return Ok(deleteCategory);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateCategory([FromRoute] int id, UpdateCategoryDTO request)
    {
      //Convert DTO to domain
      var category = new Category
      {
        Id = id,
        Name = request.CategoryName,
      };

      //Call Repository to Update Blogpost Domain Model
      var updateCategory =  _categoryRepository.Update(id, category);
      //check for null
      if (updateCategory == null)
      {
        return NotFound();
      }

      return Ok(updateCategory);
    }
  }
}
