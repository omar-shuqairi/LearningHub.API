using LearningHub.Core.data;
using LearningHub.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        Student GetStudentById(int id);
        List<StudentFullNameDto> GetStudentsFullName();
        Student GetStudentByFisrtName(string name);
        Student GetStudentByBirthDate(DateTime dob);
        List<Student> GetStudentsByBirthDateRange(DateTime strat_date, DateTime end_date);

    }
}
