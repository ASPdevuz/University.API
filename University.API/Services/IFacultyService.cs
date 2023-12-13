using University.API.Entities;

namespace University.API.Services
{
    public interface IFacultyService
    {
        Task<List<Faculty>> GetFaculty();
        Task<Faculty> GetFaculty(int id);
        Task<List<Student>> GetStudentsFaculty(int id);
    }
}
