using FluentValidation;
using University.API.Data;
using University.API.Dtos;

namespace University.API.Validator
{
    public class CreateCuorseValidator : AbstractValidator<CreateCuorseDto>
    {
        public CreateCuorseValidator(AppDbContext dbContext)
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Name should not be empty")
                .MinimumLength(3).WithMessage("Name minimum 3 characters");
            RuleFor(dto => dto.Level)
                .NotEmpty().WithMessage("Level should not be empty");
            RuleFor(dto => dto.Duration)
                .NotEmpty().WithMessage("Duration should not be empty");
        }
    }
}
