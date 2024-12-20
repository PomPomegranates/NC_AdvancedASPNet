using EvieWizarding.HealthChecks;
using EvieWizarding.Services;
using EvieWizarding.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace EvieWizarding.Controllers
{

    [Route("/api/[controller]")]

    public class TeachersController : ControllerBase
    {
        private readonly TeacherHealthCheck teacherHealthCheck;
        private readonly TeacherService teacherService;



        [HttpGet]
        public IActionResult Index()
        {
            return Ok(teacherService.GetTeachers());
        }
    }
}
