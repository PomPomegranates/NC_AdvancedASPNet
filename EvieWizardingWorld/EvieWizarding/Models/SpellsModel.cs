using EvieWizarding.Resources;
using System.Text.Json;

namespace EvieWizarding.Models
{
    public class SpellsModel
    {
        private List<Spell> _spells { get; set; }
        private Random rand = new Random();

       
        private List<Spell> ReadSpellList()
        {
            var jsonSpells = File.ReadAllText("Resources\\Spells.json");
            var spells = JsonSerializer.Deserialize<List<Spell>>(jsonSpells);
            return spells;
        }
        
        public List<Spell> ReturnSpells()
        {
            if (_spells == null) _spells = ReadSpellList();
            return _spells;
        }

        public Spell ReturnRandomSpell()
        {
            return ReturnSpells()[rand.Next(0, _spells.Count)];
        }

    }
}
