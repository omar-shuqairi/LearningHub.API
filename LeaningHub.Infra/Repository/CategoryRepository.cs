using Dapper;
using LearningHub.Core.common;
using LearningHub.Core.data;
using LearningHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaningHub.Infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {


        private readonly IDbContext _dbContext;
        public CategoryRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public List<Category> GetAllCategory()
        {
            IEnumerable<Category> result = _dbContext.Connection.Query<Category>
                ("Category_package.getallcategories", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("category_name", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Category_package.createcategory", p, commandType: CommandType.StoredProcedure);
        }


        public void UpdateCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("id", category.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("category_name", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Category_package.updatecategory", p, commandType: CommandType.StoredProcedure);
        }


        public void DeleteCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Category_package.deletecategory", p, commandType: CommandType.StoredProcedure);
        }



        public Category GetCategoryById(int id)
        {

            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Category> result = _dbContext.Connection.Query<Category>
               ("Category_package.getcategorybyid", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


    }
}
