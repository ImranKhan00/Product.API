

using Product.API.Models.Domain;
using Product.API.Models.Request;
using Product.API.Services;


namespace PigeonPad.Services
{
  public class CategoryService
  {
    private readonly cUnitOfWork unitOfWork;

    public CategoryService(cUnitOfWork unitOfWork)
    {
      this.unitOfWork = unitOfWork;
    }

    public Category Add(CategoryRequest request)
    {
      var newCategory = new Category
      {
        Name = request.Name,
      };
      unitOfWork.CategoryRepository.Add(newCategory);
      unitOfWork.Complete();
      return newCategory;
    }

    public object? GetAll()
    {
      var getAllCategories = unitOfWork.CategoryRepository.GetAll();
      return getAllCategories;
    }

    public object? GetById(int id)
    {
      var getCategoryById = unitOfWork.CategoryRepository.Get(id);
      return getCategoryById;
    }

    public Category Update(int categoryId, CategoryRequest request)
    {
      var category = unitOfWork.CategoryRepository.Get(categoryId);
      category.Name = request.Name;
      unitOfWork.CategoryRepository.Update(categoryId, category);
      unitOfWork.Complete();
      return category;
    }

    public object? Delete(int id)
    {
      var existingCategory = unitOfWork.CategoryRepository.Get(id);
      if (existingCategory != null)
      {
        unitOfWork.CategoryRepository.Delete(existingCategory);
        unitOfWork.Complete();
      }
      return existingCategory;
    }
  }
}