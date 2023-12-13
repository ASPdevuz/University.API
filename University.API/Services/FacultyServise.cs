using Microsoft.EntityFrameworkCore;
using University.API.Data;
using University.API.Entities;

namespace University.API.Services
{
    public class FacultyServise : IFacultyService
    {
        private readonly AppDbContext dbContext;
        public FacultyServise(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Faculty>> GetFacultys()
        {
            var faculty = await dbContext.Faculties
                .ToListAsync();

            if (faculty == null)
                return null;

            return faculty;
        }

        public async Task<Faculty> GetFaculty(int id)
        {
            var faculty = await dbContext.Faculties
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (faculty == null) 
                return null;

            return faculty;
        }

        public async Task<List<Student>> GetStudentsFaculty(int id)
        {
            var faculty = await dbContext.Students
                .Where(x => x.FacultyId == id)
                .Include(x => x.Faculty)
                .ToListAsync();

            if(faculty == null)
                return null;

            return faculty;
        }
    }
}
