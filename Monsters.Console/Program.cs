using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monsters.Domain.Combat;
using Monsters.Domain.Combat.Controllers;
using Monsters.Domain.Monsters;
using Monsters.Domain.Monsters.Skills;
using Monsters.Domain.Monsters.Skills.Components;
using Monsters.Domain.Monsters.Stats;

namespace Monsters.Console
{
    internal static class Program
    {
        private static void Main()
        {
            var slimeSpecies = new MonsterSpecies(
                "Slime",
                10,
                10,
                10,
                98,
                skills: new[]
                {
                    new ActiveSkill
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
                    },
                    new ActiveSkill
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
                    },
                }
            );

            var wolfSpecies = new MonsterSpecies(
                "Wolf",
                8,
                14,
                8,
                102,
                skills: new[]
                {
                    new ActiveSkill
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
                    },
                    new ActiveSkill
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
                    },
                }
            );

            var playerTeam = new List<Monster>
            {
                new(wolfSpecies, 40),
                new(slimeSpecies, 40),
            };

            var enemyTeam = new List<Monster>
            {
                new(slimeSpecies, 40),
                new(slimeSpecies, 40),
            };

            var localPlayerController = new LocalPlayerController();
            var simpleAIController = new LocalPlayerController();
            // var simpleAIController = new SimpleAIController();

            var combatSystem = new CombatSystem(playerTeam, localPlayerController);
            combatSystem.InitiateCombat(enemyTeam, simpleAIController);

            while (combatSystem.IsInProgress)
            {
                // check for all monster deaths on one side

                var activeMonster = combatSystem.GetNextActiveMonster();

                if (activeMonster == null)
                {
                    combatSystem.Tick();
                    continue;
                }

                combatSystem.CurrentTurn++;

                System.Console.WriteLine($"Turn {combatSystem.CurrentTurn}");

                var controller = activeMonster.Controller;
                var skill = controller.GetSkill(activeMonster);
                CombatMonster target;

                if (skill.Target == Target.Enemy)
                {
                    var eligibleTargets = combatSystem.AllMonsters
                        .Where(m => m.Controller != controller)
                        .Where(m => m.IsAlive)
                        .ToList();

                    target = controller.GetTarget(eligibleTargets);

                    foreach (var component in skill.Components)
                    {
                        if (component is DamageComponent damageComponent)
                        {
                            float damage = DamageCalculator.GetDamage(
                                activeMonster.CurrentStats[Stat.Attack],
                                target.CurrentStats[Stat.Defense]
                            );

                            damage *= (float) damageComponent.DamageMultiplier / 100;

                            var realDamage = (int) Math.Round(damage);

                            // var targetMaxHealth = target.Monster.Stats[Stat.Health];
                            var targetCurrentHealth = target.CurrentStats[Stat.Health];
                            var targetNewHealth = targetCurrentHealth - realDamage;

                            var damagePercentage = (1 - (float) targetNewHealth / targetCurrentHealth) * 100;

                            target.CurrentStats[Stat.Health] -= realDamage;

                            var sb = new StringBuilder();

                            sb.Append(activeMonster.Monster.Species.Name);
                            sb.Append($" (Lv {activeMonster.Monster.Level})");
                            sb.Append(" uses ");
                            sb.Append(skill.Name);
                            sb.Append(" on ");
                            sb.Append(target.Monster.Species.Name);
                            sb.Append($" (Lv {target.Monster.Level})");
                            sb.Append(" for ");
                            sb.Append(realDamage);
                            sb.Append($" ({damagePercentage:F}%) damage");

                            System.Console.WriteLine(sb);
                        }
                        else if (component is StatusEffectComponent)
                        {
                            // todo
                        }
                        else
                        {
                            // todo
                        }
                    }
                }
                else if (skill.Target == Target.Friendly)
                {
                    var eligibleTargets = combatSystem.AllMonsters
                        .Where(m => m.Controller == controller)
                        .Where(m => m.IsAlive)
                        .ToList();

                    target = controller.GetTarget(eligibleTargets);

                    // todo
                }
                else
                {
                    // todo
                }

                System.Console.WriteLine();
                activeMonster.AttackBar = 0;
            }
        }
    }
}
