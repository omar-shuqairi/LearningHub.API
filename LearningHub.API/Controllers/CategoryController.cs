using LeaningHub.Infra.Services;
using LearningHub.Core.data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public List<Category> GetAllCategory()
        {
            return _categoryService.GetAllCategory();
        }

        [HttpGet]
        [Route("getbyId/{id}")]
        public Category GetCategoryById(int id)
        {
            return _categoryService.GetCategoryById(id);
        }

        [HttpPost]
        public void CreateCategory(Category category)
        {
            _categoryService.CreateCategory(category);
        }

        [HttpPut]
        public void UpdateCategory(Category category)
        {
            _categoryService.UpdateCategory(category);
        }


        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public void DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
        }
    }
}
