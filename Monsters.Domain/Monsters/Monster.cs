using System;
using System.Collections.Generic;
using System.Text;
using Monsters.Domain.Monsters.Stats;

namespace Monsters.Domain.Monsters
{
    /// <summary>
    /// A representation of a unique monster instance.
    /// </summary>
    public class Monster
    {
        public MonsterSpecies Species { get; }
        public int Level { get; }
        public Dictionary<Stat, int> Stats { get; } = new();

        // todo: guid

        public Monster(MonsterSpecies species, int level)
        {
            Species = species;
            Level = level;

            RecalculateStats();
        }

        private void RecalculateStats()
        {
            foreach (Stat stat in Enum.GetValues(typeof(Stat)))
            {
                Stats[stat] = StatCalculator.CalculateMonsterStat(this, stat);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Species.Name} (Lv {Level})");

            foreach (Stat stat in Enum.GetValues(typeof(Stat)))
            {
                sb.AppendLine($"- {stat}: {Stats[stat]}");
            }

            return sb.ToString();
        }
    }
}
