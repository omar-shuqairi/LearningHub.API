using LearningHub.Core.data;
using LearningHub.Core.Repository;
using LearningHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaningHub.Infra.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void CreateCategory(Category category)
        {
            _categoryRepository.CreateCategory(category);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }

        public List<Category> GetAllCategory()
        {
            return _categoryRepository.GetAllCategory();
        }

        public Task<List<Category>> GetallCategoryCourse()
        {
            return _categoryRepository.GetallCategoryCourse();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.UpdateCategory(category);
        }
    }
}
