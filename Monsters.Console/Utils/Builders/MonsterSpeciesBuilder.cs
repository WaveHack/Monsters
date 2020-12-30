using System.Collections.Generic;
using Monsters.Domain.Monsters;
using Monsters.Domain.Monsters.Skills;
using Monsters.Domain.Monsters.Skills.Components;
using Monsters.Domain.Monsters.Stats;

namespace Monsters.Console.Utils.Builders
{
    public class MonsterSpeciesBuilder
    {
        private MonsterSpecies _monsterSpecies = new();

        public MonsterSpecies Build() => _monsterSpecies;

        public MonsterSpeciesBuilder Reset()
        {
            _monsterSpecies = new MonsterSpecies();
            return this;
        }

        public MonsterSpeciesBuilder SetName(string name)
        {
            _monsterSpecies.Name = name;
            return this;
        }

        public MonsterSpeciesBuilder SetStat(Stat stat, int value)
        {
            _monsterSpecies.Stats[stat] = value;
            return this;
        }

        public MonsterSpeciesBuilder SetDefaultSecondaryStats()
        {
            _monsterSpecies.Stats[Stat.Speed] = 100;
            _monsterSpecies.Stats[Stat.Accuracy] = 0;
            _monsterSpecies.Stats[Stat.Resistance] = 15;
            _monsterSpecies.Stats[Stat.CriticalRate] = 15;
            _monsterSpecies.Stats[Stat.CriticalDamage] = 50;
            return this;
        }

        public MonsterSpeciesBuilder AddSkill(Skill skill)
        {
            _monsterSpecies.Skills.Add(skill);
            return this;
        }
    }
}
