using University.API.Dtos;
using University.API.Entities;

namespace University.API.Services
{
    public class CourseServise : ICourseService
    {
        public Task<Course> CreateCourse(CreateCuorseDto newCourse)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCourse(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetCources()
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetCoursesStudent(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GetCuorseDto> GetCuorse(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Course> UpdateCourse(Guid id, UpdateCuorseDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
