using LearningHub.Core.data;
using LearningHub.Core.DTOs;
using LearningHub.Core.Repository;
using LearningHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaningHub.Infra.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void CreateStudent(Student student)
        {
            _studentRepository.CreateStudent(student);
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        public Student GetStudentByBirthDate(DateTime dob)
        {
            return _studentRepository.GetStudentByBirthDate(dob);
        }

        public Student GetStudentByFisrtName(string name)
        {
            return _studentRepository.GetStudentByFisrtName(name);
        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

        public List<Student> GetStudentsByBirthDateRange(DateTime strat_date, DateTime end_date)
        {
            return _studentRepository.GetStudentsByBirthDateRange(strat_date, end_date);
        }

        public List<string> GetStudentsFullName()
        {
            return _studentRepository.GetStudentsFullName();
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.UpdateStudent(student);
        }
    }
}
