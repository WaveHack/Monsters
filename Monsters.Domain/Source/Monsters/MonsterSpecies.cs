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
        /// Needs to be unique between all species, capitalized, and singular (i.e. "Zombie" over "Zombies"). May
        /// contain spaces.
        /// </remarks>
        /// <example>
        /// Slime, Fairy, Unicorn, Zombie, Mushroom, Lich, Dragon etc
        /// </example>
        public string Name { get; set; }

        /// <summary>
        /// The monster species' base stats.
        /// <para>Stats are separated between primary stats (Health, Attack, Defense) and secondary stats (Speed,
        /// Accuracy, Resistance, CriticalRate and CriticalDamage).</para>
        /// <para>Primary stats increase as the monster levels up, and thus enable the monster to grow in power.</para>
        /// <para>Secondary stats do NOT increase with monster level.</para>
        /// <para>All stats can be improved with gear, and in combat with things like buffs, debuffs, and auras.</para>
        /// </summary>
        public Dictionary<Stat, int> Stats { get; set; }

        /// <summary>
        /// The monster species' combat skills.
        /// <para>Combat skills allows monsters to attack, do damage, buff teammates, and the like.</para>
        /// <para>All monster species have their own unique set of combat skills, although some skills may be shared by
        /// multiple monster species (e.g. both Wolf and Bear having the same Bite skill).</para>
        /// </summary>
        public List<Skill> Skills { get; set; }

        // todo: monster role (hp, attack, defense, support)
        // todo: monster element (fire, nature, etc)

        public MonsterSpecies(
            string name,
            int health = 10,
            int attack = 10,
            int defense = 10,
            int speed = 100,
            int accuracy = 0,
            int resistance = 15,
            int criticalRate = 15,
            int criticalDamage = 50,
            IEnumerable<Skill> skills = null
        )
        {
            Name = name;

            Stats = new Dictionary<Stat, int>
            {
                {Stat.Health, health},
                {Stat.Attack, attack},
                {Stat.Defense, defense},
                {Stat.Speed, speed},
                {Stat.Accuracy, accuracy},
                {Stat.Resistance, resistance},
                {Stat.CriticalRate, criticalRate},
                {Stat.CriticalDamage, criticalDamage},
            };

            Skills = new List<Skill>();

            if (skills == null)
            {
                Skills.Add(new ActiveSkill
                {
                    Name = "Basic Attack",
                    Cooldown = 0,
                    Target = Target.Enemy,
                    Components = new List<Component>
                    {
                        new DamageComponent
                        {
                            DamageMultiplier = 80,
                        },
                    },
                });
            }
            else
            {
                foreach (var skill in skills)
                {
                    Skills.Add(skill);
                }
            }
        }

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
