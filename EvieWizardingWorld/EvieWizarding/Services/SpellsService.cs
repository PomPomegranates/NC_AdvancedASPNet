using EvieWizarding.Models;
using EvieWizarding.Resources;
using Microsoft.AspNetCore.RateLimiting;


namespace EvieWizarding.Services
{
    public class SpellsService
    {
        private readonly SpellsModel _SpellsRepository;

        public SpellsService(SpellsModel spellRepo)
        {
            _SpellsRepository = spellRepo;
        }

        public List<Spell> GetSpells()
        {
            return _SpellsRepository.ReturnSpells();
        }

        public Spell GetRandomSpell()
        {

            return _SpellsRepository.ReturnRandomSpell();
        }
    }
}
