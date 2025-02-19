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
    public class StdCourseController : ControllerBase
    {
        private readonly IStdCourseService _stdCourseService;

        public StdCourseController(IStdCourseService stdCourseService)
        {
            _stdCourseService = stdCourseService;
        }


        [HttpGet]
        public List<Stdcourse> GetAllStdCourse()
        {
            return _stdCourseService.GetAllStdCourse();
        }

        [HttpGet]
        [Route("getbyId/{id}")]
        public Stdcourse GetStdCourseById(int id)
        {
            return _stdCourseService.GetStdCourseById(id);
        }


        [HttpPost]
        public void CreateStdCourse(Stdcourse stdcourse)
        {
            _stdCourseService.CreateStdCourse(stdcourse);
        }

        [HttpPut]
        public void UpdateStdCourse(Stdcourse stdcourse)
        {
            _stdCourseService.UpdateStdCourse(stdcourse);
        }

        [HttpDelete]
        [Route("DeleteStdcourse/{id}")]

        public void DeleteStdCourse(int id)
        {
            _stdCourseService.DeleteStdCourse(id);
        }

        [HttpGet]
        [Route("TotalStudentInEachCourse")]
        public List<TotalStudent> TotalStudentInEachCourse()
        {
            return _stdCourseService.TotalStudentInEachCourse();
        }

        [HttpPost]
        [Route("SearchCourseStudent")]
        public List<Search> SearchCourseStudent(Search search)
        {
            return _stdCourseService.SearchCourseStudent(search);
        }
    }
}
