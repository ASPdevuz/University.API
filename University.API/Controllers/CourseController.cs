using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.API.Dtos;
using University.API.Services;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService service;
        private readonly IValidator<CreateCuorseDto> createValidator;
        private readonly IValidator<UpdateCuorseDto> updateValidator;

        public CourseController(ICourseService service,
            IValidator<CreateCuorseDto> createValidator,
            IValidator<UpdateCuorseDto> updateValidator)
        {
            this.service = service;
            this.createValidator = createValidator;
            this.updateValidator = updateValidator;
        }

        [HttpPost("CreateCourse")]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCuorseDto dto)
        {
            var validationResult = await createValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var request = await service.CreateCourse(dto);
            return CreatedAtAction(nameof(GetCourse), new { id = request.Id }, request);
        }

        [HttpGet("Courses")]
        public async Task<IActionResult> GetCourses()
        {
            var request = await service.GetCources();
            return Ok(request);
        }

        [HttpGet("Course/{id}")]
        public async Task<IActionResult> GetCourse([FromRoute] Guid id)
        {
            var request = await service.GetCuorse(id);
            return Ok(request);
        }
        [HttpPut("UpdateCourse/{id}")]
        public async Task<IActionResult> UpdateCourse(
            [FromRoute] Guid id,
            UpdateCuorseDto dto)
        {
            var validationResult = await updateValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var request = await service.UpdateCourse(id, dto);
            return Ok(request);
        }
        [HttpDelete("DeleteCourse/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var request = await service.DeleteCourse(id);
            return Ok(request);
        }
        [HttpGet("Course/Students/{id}")]
        public async Task<IActionResult> GetCourseStudent([FromRoute] Guid id)
        {
            var request = await service.GetCoursesStudent(id);
            return Ok(request);
        }
    }
}
