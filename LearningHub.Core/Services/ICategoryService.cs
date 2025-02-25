using LearningHub.Core.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Services
{
    public interface ICategoryService
    {
        List<Category> GetAllCategory();
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
        Category GetCategoryById(int id);
        Task<List<Category>> GetallCategoryCourse();

    }
}
