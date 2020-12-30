using System.Collections.Generic;
using Monsters.Domain.Combat.Controllers;
using Monsters.Domain.Monsters;
using Monsters.Domain.Monsters.Stats;

namespace Monsters.Domain.Combat
{
    public class CombatMonster
    {
        public int Index { get; set; }
        public Controller Controller { get; set; }
        public Monster Monster { get; set; }
        public Dictionary<Stat, int> CurrentStats { get; set; }
        public float AttackBar { get; set; }

        public bool IsAlive => CurrentStats[Stat.Health] > 0;

        public override string ToString()
        {
            return $"Lv {Monster.Level} {Monster.Species.Name} (Health: {CurrentStats[Stat.Health]}/{Monster.Stats[Stat.Health]})";
        }
    }
}
