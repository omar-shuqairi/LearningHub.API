using LearningHub.Core.data;
using LearningHub.Core.Repository;
using LearningHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaningHub.Infra.Services
{
    public class StdCourseService : IStdCourseService
    {
        private readonly IStdCourseRepository _stdCourseRepository;

        public StdCourseService(IStdCourseRepository stdCourseRepository)
        {
            _stdCourseRepository = stdCourseRepository;
        }

        public void CreateStdCourse(Stdcourse stdcourse)
        {
            _stdCourseRepository.CreateStdCourse(stdcourse);
        }

        public void DeleteStdCourse(int id)
        {
            _stdCourseRepository.DeleteStdCourse(id);
        }

        public List<Stdcourse> GetAllStdCourse()
        {
            return _stdCourseRepository.GetAllStdCourse();
        }

        public Stdcourse GetStdCourseById(int id)
        {
            return _stdCourseRepository.GetStdCourseById(id);
        }

        public void UpdateStdCourse(Stdcourse stdcourse)
        {
            _stdCourseRepository.UpdateStdCourse(stdcourse);
        }
    }
}
