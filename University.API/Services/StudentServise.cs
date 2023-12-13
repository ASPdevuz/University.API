using University.API.Dtos;
using University.API.Entities;

namespace University.API.Services
{
    public class StudentServise : IStudentService
    {
        public Task<Student> CreateStudent(CreateStudentDto newStudent)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudent(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Task<GetStudentDto> GetStudent(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudent(Guid id, UpdateStudentDto student)
        {
            throw new NotImplementedException();
        }
    }
}
