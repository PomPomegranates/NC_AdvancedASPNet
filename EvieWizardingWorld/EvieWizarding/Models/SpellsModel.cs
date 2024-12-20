using EvieWizarding.Resources;
using System.Text.Json;

namespace EvieWizarding.Models
{
    public class SpellsModel
    {
        private List<Spell> _spells { get; set; }

       
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
    }
}
