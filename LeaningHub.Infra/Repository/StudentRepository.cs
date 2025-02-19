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
    public class StudentRepository : IStudentRepository
    {

        private readonly IDbContext _dbContext;
        public StudentRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public List<Student> GetAllStudents()
        {
            IEnumerable<Student> result = _dbContext.Connection.Query<Student>
               ("Student_package.getallstudents", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        public void CreateStudent(Student student)
        {
            var p = new DynamicParameters();
            p.Add("firstname", student.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("lastname", student.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("dob", student.Dateofbirth, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Student_package.createstudent", p, commandType: CommandType.StoredProcedure);
        }
        public void UpdateStudent(Student student)
        {
            var p = new DynamicParameters();
            p.Add("id", student.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("firstname", student.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("lastname", student.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("dob", student.Dateofbirth, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Student_package.updatestudent", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteStudent(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Student_package.deletestudent", p, commandType: CommandType.StoredProcedure);
        }


        public Student GetStudentById(int id)
        {

            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Student> result = _dbContext.Connection.Query<Student>
               ("Student_package.getstudentbyid", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<string> GetStudentsFullName()
        {
            IEnumerable<string> result = _dbContext.Connection.Query<string>
               ("Student_package.getstudentsfullname", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }


        public Student GetStudentByFisrtName(string name)
        {
            var p = new DynamicParameters();
            p.Add("f_name", name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Student> result = _dbContext.Connection.Query<Student>
               ("Student_package.getstudentbyfirstname", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Student GetStudentByBirthDate(DateTime dob)
        {
            var p = new DynamicParameters();
            p.Add("dob", dob, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<Student> result = _dbContext.Connection.Query<Student>
               ("Student_package.getstudentbybirthdate", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<Student> GetStudentsByBirthDateRange(DateTime strat_date, DateTime end_date)
        {
            var p = new DynamicParameters();
            p.Add("startdate", strat_date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("enddate", end_date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<Student> result = _dbContext.Connection.Query<Student>
               ("Student_package.getstudentsbybirthdaterange", p, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
    }
}
