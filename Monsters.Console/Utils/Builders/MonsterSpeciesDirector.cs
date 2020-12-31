using System.Collections.Generic;
using Monsters.Domain.Monsters;
using Monsters.Domain.Monsters.Skills;
using Monsters.Domain.Monsters.Skills.Components;
using Monsters.Domain.Monsters.Stats;

namespace Monsters.Console.Utils.Builders
{
    public class MonsterSpeciesDirector
    {
        private readonly MonsterSpeciesBuilder _builder;

        public MonsterSpeciesDirector(MonsterSpeciesBuilder builder)
        {
            _builder = builder;
        }

        public MonsterSpecies CreateSlime()
        {
            return _builder
                .Reset()
                .SetName("Slime")
                .SetDefaultSecondaryStats()
                .SetStat(Stat.Health, 10)
                .SetStat(Stat.Attack, 10)
                .SetStat(Stat.Defense, 10)
                .AddSkill(new ActiveSkill("Slime", Target.Enemy), new Component[]
                {
                    new DamageComponent(.8f),
                    new StatusEffectComponent(StatusEffect.Poison, .2f),
                })
                .AddSkill(new ActiveSkill("Spread Goo", Target.EnemyTeam, 2), new Component[]
                {
                    new DamageComponent(.2f),
                    new DamageComponent(.2f),
                    new StatusEffectComponent(StatusEffect.Poison, .2f),
                })
                .Build();
        }

        public MonsterSpecies CreateWolf()
        {
            return _builder
                .Reset()
                .SetName("Wolf")
                .SetDefaultSecondaryStats()
                .SetStat(Stat.Health, 8)
                .SetStat(Stat.Attack, 14)
                .SetStat(Stat.Defense, 8)
                .SetStat(Stat.Speed, 102)
                .AddSkill(new ActiveSkill("Claw", Target.Enemy), new Component[]
                {
                    new DamageComponent(.9f),
                })
                .AddSkill(new ActiveSkill("Bite", Target.Enemy, 2), new Component[]
                {
                    new DamageComponent(.6f),
                    new DamageComponent(.6f),
                })
                .Build();
        }
    }
}
