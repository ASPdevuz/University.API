using FluentValidation;
using University.API.Data;
using University.API.Dtos;

namespace University.API.Validator
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentDto>
    {
        public CreateStudentValidator(AppDbContext dbContext) 
        {
            RuleFor(dto => dto.Fullname)
                .NotEmpty().WithMessage("Fullname should not be empty")
                .MinimumLength(8).WithMessage("Fullname minimum 8 characters")
                .MaximumLength(50).WithMessage("Fullname maximum 50 characters");
            RuleFor(dto => dto.PhoneNumber)
                .NotEmpty().WithMessage("Phonenumber should not be empty")
                .MaximumLength(13).WithMessage("Phonenumber maximum 13 characters");
            RuleFor(dto => dto.Age)
                .NotEmpty().WithMessage("Age should not be empty");
            RuleFor(dto => dto.Direction)
                .NotEmpty().WithMessage("Direction should not be empty");
            RuleFor(dto => dto.Degree)
                .NotEmpty().WithMessage("Degree should not be empty");
            RuleFor(dto => dto.FacultyId)
                .NotNull().WithMessage("FacultyId should not be null")
                .GreaterThan(0).WithMessage("FacultyId should be greater than 0");
        }
    }
}
