using Microsoft.EntityFrameworkCore;
using University.API.Entities;

namespace University.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>()
            .HasKey(c => c.Id); 
            builder.Entity<Course>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Entity<Course>()
                .Property(c => c.Level)
                .IsRequired(); 
            builder.Entity<Course>()
                .HasMany(c => c.Students) 
                .WithMany(s => s.Courses); 
            builder.Entity<Student>()
                .HasKey(s => s.Id); 
            builder.Entity<Student>()
                .Property(s => s.Fullname)
                .IsRequired()
                .HasMaxLength(100);
            builder.Entity<Student>()
                .Property(s => s.Age)
                .IsRequired();
            builder.Entity<Student>()
                .Property(s => s.PhoneNumber)
                .HasMaxLength(13);
            builder.Entity<Course>()
                .Property(s => s.Duration)
                .HasMaxLength(20);
            builder.Entity<Student>()
                .Property(s => s.Direction)
                .IsRequired()
                .HasMaxLength(100);
            builder.Entity<Student>()
                .Property(s => s.Degree)
                .IsRequired();
            builder.Entity<Student>()
                .HasOne(s => s.Faculty)
                .WithMany()
                .HasForeignKey(s => s.FacultyId)
                .IsRequired();
            builder.Entity<Student>()
                .HasMany(s => s.Courses) 
                .WithMany(c => c.Students);
            builder.Entity<Faculty>()
                .HasKey(f => f.Id);
            builder.Entity<Faculty>()
                .Property(f => f.Name)
                .HasMaxLength(100);
            builder.Entity<Faculty>()
                .HasData(
                    new { Id = 1, Name = "Injinering" },
                    new { Id = 2, Name = "Tabiiy fanlar" },
                    new { Id = 3, Name = "Biznes av Menejment" },
                    new { Id = 4, Name = "San'at va Media" },
                    new { Id = 5, Name = "Tibbiyot" },
                    new { Id = 6, Name = "Ijtimoiy ilimlar"}
                );

            base.OnModelCreating(builder);
        }
    }
}
