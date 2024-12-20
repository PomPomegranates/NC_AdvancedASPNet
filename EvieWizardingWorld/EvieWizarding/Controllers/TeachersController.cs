using EvieWizarding.HealthChecks;
using EvieWizarding.Services;
using EvieWizarding.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace EvieWizarding.Controllers
{
    [ApiController]
    [Route("/[controller]")]

    public class TeachersController : ControllerBase
    {
        private readonly TeacherHealthCheck teacherHealthCheck;
        private readonly TeachersService _teachersService;

        public TeachersController(TeachersService teachersService)
        {
            _teachersService = teachersService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_teachersService.GetTeachers());
        }

        [HttpGet("{id}")]
        public IActionResult GetTeacherByID(string id)
        {
            if (int.TryParse(id, out int result))
            {
                var teacher = _teachersService.GetTeachers(result);
                if (teacher != null) return Ok(teacher);
                else return NotFound($"Error 404: Teacher Id - {id} - Not Found");
            }
            else return BadRequest($"Error 400, {id} is not a valid teacher ID");
        }

        [HttpPost]
        public IActionResult PostTeacher([FromBody] Teacher teacher)
        {
            //new Teacher() {name}
            if (string.IsNullOrWhiteSpace(teacher.name) )
            {
                return BadRequest($"Error 400, {teacher.name} - Name cannot be null.");
            }
            if (_teachersService.AddTeacher(teacher, out Teacher result))
            {
                return Created(teacher.id.ToString(), teacher);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
