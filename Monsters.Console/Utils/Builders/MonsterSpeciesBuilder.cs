﻿using System.Collections.Generic;
using Monsters.Domain.Monsters;
using Monsters.Domain.Monsters.Skills;
using Monsters.Domain.Monsters.Skills.Components;
using Monsters.Domain.Monsters.Stats;

namespace Monsters.Console.Utils.Builders
{
    public class MonsterSpeciesBuilder
    {
        private static readonly Dictionary<Stat, int> DefaultSecondaryStats = new()
        {
            {Stat.Speed, 100},
            {Stat.Accuracy, 0},
            {Stat.Resistance, 15},
            {Stat.CriticalRate, 15},
            {Stat.CriticalDamage, 50},
        };

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
            foreach (var (stat, value) in DefaultSecondaryStats)
                _monsterSpecies.Stats[stat] = value;

            return this;
        }

        public MonsterSpeciesBuilder AddSkill(Skill skill)
        {
            _monsterSpecies.Skills.Add(skill);
            return this;
        }

        public MonsterSpeciesBuilder AddSkill(ActiveSkill skill, IEnumerable<Component> components)
        {
            skill.Components.AddRange(components);
            return AddSkill(skill);
        }
    }
}
