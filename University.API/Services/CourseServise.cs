using Microsoft.EntityFrameworkCore;
using University.API.Data;
using University.API.Dtos;
using University.API.Entities;

namespace University.API.Services
{
    public class CourseServise : ICourseService
    {
        private readonly AppDbContext dbContext;
        public CourseServise(AppDbContext dbContext) 
            => this.dbContext = dbContext;

        public async Task<Course> CreateCourse(CreateCuorseDto newCourse)
        {
            var create = new Course
            {
                Id = Guid.NewGuid(),
                Name = newCourse.Name,
                Level = newCourse.Level,
                Duration = newCourse.Duration,
            };

            await dbContext.Courses.AddAsync(create);
            await dbContext.SaveChangesAsync();
            return create;
        }

        public async Task<bool> DeleteCourse(Guid id)
        {
            var student = await dbContext.Students
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            if (student == null)
                return false;

            dbContext.Students .Remove(student);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Course>> GetCources()
        {
           var student = await dbContext.Courses
                .ToListAsync();

            if (student is null)
                return null;

            return student;
        }

        public async Task<List<Course>> GetCoursesStudent(Guid id)
        {
            var course = await dbContext.Courses
                .Where(s => s.Id == id)
                .Include(s => s.Students)
                .ToListAsync();

            if (course is null)
                return null;

            return course;
        }

        public async Task<GetCuorseDto> GetCuorse(Guid id)
        {
            var course = await dbContext.Courses
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            if(course is null)
                return null;

            var result = new GetCuorseDto(course);
            return result;
        }

        public async Task<Course> UpdateCourse(Guid id, UpdateCuorseDto dto)
        {
           var update = await dbContext.Courses
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync(); 

            if (update is null)
                return null;

            update.Name = dto.Name;
            update.Level = dto.Level;
            update.Duration = dto.Duration;

            await dbContext.SaveChangesAsync();
            return update;
        }
    }
}
