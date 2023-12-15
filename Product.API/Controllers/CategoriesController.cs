using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Product.API.Models.Domain;
using Product.API.Models.DTO_s;
using Product.API.Respositories.Implementation;
using Product.API.Respositories.Interfaces;

namespace Product.API.Controllers
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
      var categories = await _categoryRepository.GetAllAsync();
      //map model to DTO
      var response = new List<CategoryDTO>();
      foreach (var category in categories)
      {
        response.Add(new CategoryDTO
        {
          Id = category.Id,
          CategoryName = category.CategoryName,
          Description = category.Description,
        });
      }
      return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
      //getting category by id
      var category = await _categoryRepository.GetByIdAsync(id);
      if (category is null)
      {
        return NotFound();
      }
      var response = new CategoryDTO
      {
        Id = category.Id,
        CategoryName = category.CategoryName,
        Description = category.Description,
      };
      return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO request)
    {
      //Convert DTO to domain
      var category = new Category
      {
        CategoryName = request.CategoryName,
        Description = request.Description
      };

      category = await _categoryRepository.CreateAsync(category);
      //Convert Domain to DTO
      var response = new CategoryDTO
      {
       CategoryName = category.CategoryName,
       Description = category.Description
      };
      return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] int id)
    {
      var deleteCategory = await _categoryRepository.DeleteAsync(id);
      if (deleteCategory == null)
      {
        return NotFound();
      }
      //Convert Domain Model to DTO
      var response = new CategoryDTO
      {
        Id = deleteCategory.Id,
        CategoryName = deleteCategory.CategoryName,
        Description = deleteCategory.Description,
      };
      return Ok(response);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateCategory([FromRoute] int id, UpdateCategoryDTO request)
    {
      //Convert DTO to domain
      var category = new Category
      {
        Id = id,
        CategoryName = request.CategoryName,
        Description = request.Description,
      };

      //Call Repository to Update Blogpost Domain Model
      var updateCategory = await _categoryRepository.UpdateAsync(category);
      //check for null
      if (updateCategory == null)
      {
        return NotFound();
      }

      //convert Domain Model to DTO
      var response = new CategoryDTO
      {
        Id = category.Id,
        CategoryName = category.CategoryName,
        Description = category.Description,
      };
      return Ok(response);
    }
  }
}
