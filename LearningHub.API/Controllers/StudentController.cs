using LeaningHub.Infra.Services;
using LearningHub.Core.data;
using LearningHub.Core.DTOs;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public List<Student> GetAllStudent()
        {
            return _studentService.GetAllStudents();
        }

        [HttpGet]
        [Route("getbyId/{id}")]
        public Student GetStudentById(int id)
        {
            return _studentService.GetStudentById(id);
        }

        [HttpPost]
        public void CreateStudent(Student student)
        {
            _studentService.CreateStudent(student);
        }

        [HttpPut]
        public void UpdateStudent(Student student)
        {
            _studentService.UpdateStudent(student);
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]

        public void DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
        }


        [HttpGet]
        [Route("GetStudentsFullName")]
        public List<string> GetStudentsFullName()
        {
            return _studentService.GetStudentsFullName();
        }


        [HttpGet]
        [Route("GetStudentByFirstName/{name}")]
        public Student GetStudentByFirstName(string name)
        {
            return _studentService.GetStudentByFisrtName(name);
        }

        [HttpGet]
        [Route("GetStudentByBirthDate/{dob}")]
        public Student GetStudentByBirthDate(DateTime dob)
        {
            return _studentService.GetStudentByBirthDate(dob);
        }


        [HttpGet]
        [Route("GetStudentsByBirthDateRange/{StartDate}/{EndDate}")]
        public List<Student> GetStudentsByBirthDateRange(DateTime StartDate, DateTime EndDate)
        {
            return _studentService.GetStudentsByBirthDateRange(StartDate, EndDate);
        }
    }
}
