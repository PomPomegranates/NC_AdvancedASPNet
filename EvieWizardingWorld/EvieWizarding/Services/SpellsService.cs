using EvieWizarding.Models;
using EvieWizarding.Resources;

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
    }
}
