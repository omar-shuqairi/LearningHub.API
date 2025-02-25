using LearningHub.Core.data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public List<Course> GetAllCourses()
        {
            return _courseService.GetAllCourses();
        }

        [HttpGet]
        [Route("getbyId/{id}")]
        public Course GetCourseById(int id)
        {
            return _courseService.GetCourseById(id);
        }


        [HttpPost]
        public void CreateCourse(Course course)
        {
            _courseService.CreateCourse(course);
        }

        [HttpPut]
        public void UpdateCourse(Course course)
        {
            _courseService.UpdateCourse(course);
        }

        [HttpDelete]
        [Authorize]
        [CheckClaimsAtt("RoleId", "3")]
        [Route("DeleteCourse/{id}")]

        public void DeleteCourse(int id)
        {
            _courseService.DeleteCourse(id);
        }


        [HttpPost]
        [Route("UploadImage")]
        public Course UploadImage()
        {
            var file = Request.Form.Files[0];
            var filename = Guid.NewGuid().ToString() + "_" + file.Name;
            var fullPath = Path.Combine("images", filename);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Course item = new Course();
            item.Imagename = filename;
            return item;
        }
    }
}
