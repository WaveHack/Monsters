using System.Collections.Generic;
using System.Text;
using Monsters.Domain.Monsters.Skills;
using Monsters.Domain.Monsters.Skills.Components;
using Monsters.Domain.Monsters.Stats;

namespace Monsters.Domain.Monsters
{
    /// <summary>
    /// The class representing a unique monster species.
    /// </summary>
    /// <remarks>
    /// This class is just for declaring specific monster species, and not an individual player-owned monster (with
    /// level, calculated stats etc). Please see <see cref="Monster"/> for that.
    /// </remarks>
    public class MonsterSpecies
    {
        /// <summary>
        /// The monster species' name.
        /// </summary>
        /// <remarks>
        /// Constraints:<br/>
        /// - Must be unique between all monster species,<br/>
        /// - Must be properly capitalized,<br/>
        /// - Must be singular (i.e. "Zombie" over "Zombies"),<br/>
        /// - May contain spaces.
        /// </remarks>
        /// <example>
        /// Slime, Fairy, Unicorn, Zombie, Mushroom, Lich King, Dragon etc
        /// </example>
        public string Name { get; set; }

        /// <summary>
        /// The monster species' base stats.
        /// </summary>
        /// <remarks>
        /// <para>Stats are separated between primary stats (Health, Attack, Defense) and secondary stats (Speed,
        /// Accuracy, Resistance, CriticalRate and CriticalDamage).</para>
        /// <para>Primary stats increase as the monster levels up, and thus enable the monster to grow in power.</para>
        /// <para>Secondary stats do NOT increase with monster level.</para>
        /// <para>All stats can be improved with equipment, and in combat with things like buffs, debuffs, and
        /// auras.</para>
        /// </remarks>
        public Dictionary<Stat, int> Stats { get; } = new();

        /// <summary>
        /// The monster species' combat skills.
        /// </summary>
        /// <remarks>
        /// <para>Combat skills allows monsters to attack, do damage, buff teammates, and the like.</para>
        /// <para>All monster species have their own unique set of combat skills, although some skills may be shared by
        /// multiple monster species (e.g. both Wolf and Bear having the same Bite skill).</para>
        /// </remarks>
        public List<Skill> Skills { get; } = new();

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Monster Species: {Name}");

            sb.AppendLine("Stats:");
            foreach (var (statType, value) in Stats)
            {
                sb.AppendLine($"- {statType}: {value}");
            }

            sb.AppendLine("Skills:");
            foreach (var skill in Skills)
            {
                sb.AppendLine($"- {skill.Name}");
            }

            return sb.ToString();
        }
    }
}
