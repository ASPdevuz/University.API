using System.Diagnostics.Metrics;
using University.API.Dtos;
using University.API.Entities;

namespace University.API.Services
{
    public interface ICourseService
    {
        Task<List<Course>> GetCources();
        Task<GetCuorseDto> GetCuorse(Guid id);
        Task<List<Course>> GetCoursesStudent(Guid id);
        Task<Course> CreateCourse(CreateCuorseDto newCourse);
        Task<Course> UpdateCourse(Guid id, UpdateCuorseDto dto);
        Task<bool> DeleteCourse(Guid id);

    }
}
