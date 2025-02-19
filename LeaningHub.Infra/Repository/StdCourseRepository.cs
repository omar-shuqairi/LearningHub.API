using Dapper;
using LearningHub.Core.common;
using LearningHub.Core.data;
using LearningHub.Core.DTOs;
using LearningHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaningHub.Infra.Repository
{
    public class StdCourseRepository : IStdCourseRepository
    {

        private readonly IDbContext _dbContext;
        public StdCourseRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public void CreateStdCourse(Stdcourse stdcourse)
        {
            var p = new DynamicParameters();
            p.Add("markstd", stdcourse.Markofstd, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("registerdate", stdcourse.Dateofregister, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("course_id", stdcourse.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("student_id", stdcourse.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("StdCourse_package.createstdcourse", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteStdCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("StdCourseId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("StdCourse_package.deletestdcourse", p, commandType: CommandType.StoredProcedure);
        }

        public List<Stdcourse> GetAllStdCourse()
        {
            IEnumerable<Stdcourse> result = _dbContext.Connection.Query<Stdcourse>
               ("StdCourse_package.getallstdcourse", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Stdcourse GetStdCourseById(int id)
        {
            var p = new DynamicParameters();
            p.Add("StdCourseId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Stdcourse> result = _dbContext.Connection.Query<Stdcourse>
               ("StdCourse_package.getstdcoursebyid", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateStdCourse(Stdcourse stdcourse)
        {
            var p = new DynamicParameters();
            p.Add("markstd", stdcourse.Markofstd, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("registerdate", stdcourse.Dateofregister, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("course_id", stdcourse.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("student_id", stdcourse.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("StdCourse_package.updatestdcourse", p, commandType: CommandType.StoredProcedure);
        }
        public List<TotalStudent> TotalStudentInEachCourse()
        {
            IEnumerable<TotalStudent> result = _dbContext.Connection.Query<TotalStudent>
               ("StdCourse_package.TotalStudentInEachCourse", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<Search> SearchCourseStudent(Search search)
        {
            var p = new DynamicParameters();
            p.Add("StdName", search.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cName", search.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Datefrom", search.DateFrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("dateto", search.DateTo, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Search>
               ("StdCourse_package.SearchCourseStudent", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
