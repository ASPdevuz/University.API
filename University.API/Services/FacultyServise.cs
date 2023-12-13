using University.API.Entities;

namespace University.API.Services
{
    public class FacultyServise : IFacultyService
    {
        public Task<List<Faculty>> GetFacultys()
        {
            throw new NotImplementedException();
        }

        public Task<Faculty> GetFaculty(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetStudentsFaculty(int id)
        {
            throw new NotImplementedException();
        }
    }
}
