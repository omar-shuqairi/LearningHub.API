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
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbContext _dbContext;
        public CourseRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public List<Course> GetAllCourses()
        {
            IEnumerable<Course> result = _dbContext.Connection.Query<Course>
                ("Course_package.GetAllCourses", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public void CreateCourse(Course course)
        {
            var p = new DynamicParameters();
            p.Add("course_name", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("catId", course.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("img", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Course_package.CreateCourse", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateCourse(Course course)
        {
            var p = new DynamicParameters();
            p.Add("id", course.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("course_name", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("catId", course.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("img", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Course_package.UpdateCourse", p, commandType: CommandType.StoredProcedure);
        }
        public void DeleteCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Course_package.DeleteCourse", p, commandType: CommandType.StoredProcedure);
        }



        public Course GetCourseById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Course> result = _dbContext.Connection.Query<Course>
               ("Course_package.GetCourseById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

    }
}
