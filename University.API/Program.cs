using FluentValidation;
using Microsoft.EntityFrameworkCore;
using University.API.Data;
using University.API.Dtos;
using University.API.Services;
using University.API.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("localhost");
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AppDbContext>(o
=> o.UseSqlServer(connectionString));

builder.Services.AddScoped<ICourseService, CourseServise>();
builder.Services.AddScoped<IFacultyService, FacultyServise>();
builder.Services.AddScoped<IStudentService, StudentServise>();
builder.Services.AddTransient<IValidator<CreateCuorseDto>, CreateCuorseValidator>();
builder.Services.AddTransient<IValidator<UpdateCuorseDto>, UpdateCuorseValidator>();
builder.Services.AddTransient<IValidator<CreateStudentDto>, CreateStudentValidator>();
builder.Services.AddTransient<IValidator<UpdateStudentDto>, UpdateStudentValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
