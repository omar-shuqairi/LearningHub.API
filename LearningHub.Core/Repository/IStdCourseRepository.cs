using LearningHub.Core.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface IStdCourseRepository
    {
        List<Stdcourse> GetAllStdCourse();
        void CreateStdCourse(Stdcourse stdcourse);
        void UpdateStdCourse(Stdcourse stdcourse);
        void DeleteStdCourse(int id);
        Stdcourse GetStdCourseById(int id);
    }
}
