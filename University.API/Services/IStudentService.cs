using University.API.Dtos;
using University.API.Entities;

namespace University.API.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
        Task<GetStudentDto> GetStudent(Guid id);
        Task<Student> CreateStudent(CreateStudentDto newStudent);
        Task<Student> UpdateStudent(Guid id,UpdateStudentDto student);
        Task<bool> DeleteStudent(Guid id);
    }
}
