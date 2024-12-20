using EvieWizarding.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvieWizarding.Controllers
{
    [Route("/api/[controller]")]
    public class SpellsController : ControllerBase
    {
        private readonly SpellsService _spellService;

        public SpellsController( SpellsService spellsService)
        {
            _spellService = spellsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_spellService.GetSpells());
        }
    }
}
