using System.Collections.Generic;
using Monsters.Domain.Monsters;
using Monsters.Domain.Monsters.Skills;
using Monsters.Domain.Monsters.Skills.Components;
using Monsters.Domain.Monsters.Stats;

namespace Monsters.Console.Utils.Builders
{
    public class MonsterSpeciesDirector
    {
        private MonsterSpeciesBuilder _builder;

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
                .AddSkill(new ActiveSkill
                {
                    Name = "Slime",
                    Cooldown = 0,
                    Target = Target.Enemy,
                    Components = new List<Component>
                    {
                        new DamageComponent
                        {
                            DamageMultiplier = 80,
                        },
                        new StatusEffectComponent
                        {
                            ChanceToApply = 20,
                            StatusEffect = StatusEffect.Poison,
                            AmountOfTurns = 2,
                        },
                    }
                })
                .AddSkill(new ActiveSkill
                {
                    Name = "Spread Goo",
                    Cooldown = 2,
                    Target = Target.EnemyTeam,
                    Components = new List<Component>
                    {
                        new DamageComponent
                        {
                            DamageMultiplier = 20,
                        },
                        new DamageComponent
                        {
                            DamageMultiplier = 20,
                        },
                        new StatusEffectComponent
                        {
                            ChanceToApply = 20,
                            StatusEffect = StatusEffect.Poison,
                            AmountOfTurns = 2,
                        },
                    }
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
                .AddSkill(new ActiveSkill
                {
                    Name = "Claw",
                    Cooldown = 0,
                    Target = Target.Enemy,
                    Components = new List<Component>
                    {
                        new DamageComponent
                        {
                            DamageMultiplier = 90,
                        },
                    }
                })
                .AddSkill(new ActiveSkill
                {
                    Name = "Bite",
                    Cooldown = 2,
                    Target = Target.Enemy,
                    Components = new List<Component>
                    {
                        new DamageComponent
                        {
                            DamageMultiplier = 60,
                        },
                        new DamageComponent
                        {
                            DamageMultiplier = 60,
                        },
                    }
                })
                .Build();
        }
    }
}
