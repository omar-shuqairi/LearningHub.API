using LearningHub.Core.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAllCourses();
        void CreateCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
        Course GetCourseById(int id);
    }
}
