using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.API.Services;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService service;

        public FacultyController(IFacultyService service)
            => this.service = service;
        [HttpGet("GetFacultys")]
        public async Task<IActionResult> GetFacultys()
        {
            var request = await service.GetFacultys();
            return Ok(request);
        }
        [HttpGet("Faculty/{id}")]
        public async Task<IActionResult> GetFaculty(int id)
        {
            var request = await service.GetFaculty(id);
            return Ok(request);
        }
        [HttpGet("Student/Faculty/{id}")]
        public async Task<IActionResult> GetStudentsFaculty(int id)
        {
            var request = await service.GetStudentsFaculty(id);
            return Ok(request);
        }
    }
}
