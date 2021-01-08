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
                .SetStat(Stat.Health, 100)
                .SetStat(Stat.Attack, 100)
                .SetStat(Stat.Defense, 100)
                .AddSkill(new ActiveSkill(
                    "Spit",
                    "Spits at the enemy for 80% damage. Has a 20% chance to apply poison for 2 turns.",
                    Target.Enemy
                ), new Component[]
                {
                    new DamageComponent(.8f),
                    new StatusEffectComponent(StatusEffect.Poison, .2f),
                })
                .AddSkill(new ActiveSkill(
                    "Spread Goo",
                    "Covers the enemy in goo for 2x20% damage and lowers their speed for 2 turns. Has a 20% chance to apply poison for 2 turns.",
                    Target.EnemyTeam,
                    2
                ), new Component[]
                {
                    new DamageComponent(.2f),
                    new DamageComponent(.2f),
                    new StatusEffectComponent(StatusEffect.SpeedBreak),
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
                .SetStat(Stat.Health, 80)
                .SetStat(Stat.Attack, 140)
                .SetStat(Stat.Defense, 80)
                .SetStat(Stat.Speed, 102)
                .AddSkill(new ActiveSkill(
                    "Claw",
                    "Claws the enemy for 90% damage.",
                    Target.Enemy
                ), new Component[]
                {
                    new DamageComponent(.9f),
                })
                .AddSkill(new ActiveSkill(
                    "Bite",
                    "Bites the enemy for 2x60% damage.",
                    Target.Enemy,
                    2
                ), new Component[]
                {
                    new DamageComponent(.6f),
                    new DamageComponent(.6f),
                })
                .AddSkill(new ActiveSkill(
                    "Howl",
                    "Increases your team's attack and critical rate for 2 turns.",
                    Target.FriendlyTeam,
                    3
                ), new Component[]
                {
                    new StatusEffectComponent(StatusEffect.AttackBoost),
                    new StatusEffectComponent(StatusEffect.CriticalRateBoost),
                })
                .Build();
        }
    }
}
