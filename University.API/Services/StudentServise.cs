using Microsoft.EntityFrameworkCore;
using University.API.Data;
using University.API.Dtos;
using University.API.Entities;

namespace University.API.Services
{
    public class StudentServise : IStudentService
    {
        private readonly AppDbContext dbContext;

        public StudentServise(AppDbContext dbContext)
            => this.dbContext = dbContext;
        public async Task<Student> CreateStudent(CreateStudentDto newStudent)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                Fullname = newStudent.Fullname,
                PhoneNumber = newStudent.PhoneNumber,
                Age = newStudent.Age,
                Direction = newStudent.Direction,
                Degree = newStudent.Degree,
                FacultyId = newStudent.FacultyId
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return student;
        }

        public async Task<bool> DeleteStudent(Guid id)
        {
            var student = await dbContext.Students
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            if (student is null)
                return false;

            dbContext.Students.Remove(student);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var student = await dbContext.Students
                .Include(s => s.Faculty)
                .ToListAsync();

            if (student is null)
                return null;

            return student;
        }

        public async Task<GetStudentDto> GetStudent(Guid id)
        {
            var student = await dbContext.Students
                .Where(s => s.Id == id)
                .Include(s => s.Faculty)
                .FirstOrDefaultAsync();

            if (student is null)
                return null;

            var result = new GetStudentDto(student);
            return result;
        }

        public async Task<Student> UpdateStudent(Guid id, UpdateStudentDto student)
        {
            var updated = await dbContext.Students
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            if (updated is null)
                return null;

            updated.Fullname = student.Fullname;
            updated.PhoneNumber = student.PhoneNumber;
            updated.Age = student.Age;
            updated.Direction = student.Direction;
            updated.Degree = student.Degree;
            updated.FacultyId = student.FacultyId;

            await dbContext.SaveChangesAsync();
            return updated;
        }
    }
}
