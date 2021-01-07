using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monsters.Console.Utils;
using Monsters.Console.Utils.Builders;
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
            var builder = new MonsterSpeciesBuilder();
            var director = new MonsterSpeciesDirector(builder);

            var slimeSpecies = director.CreateSlime();
            var wolfSpecies = director.CreateWolf();

            System.Console.WriteLine();
            foreach (var level in new[] {/*1, 5, 10, 20, 30, */40})
            {
                var attacker = new Monster(wolfSpecies, level);
                var defender = new Monster(slimeSpecies, level);

                DamageReporter.ReportDamage(attacker, defender);

                System.Console.WriteLine();
            }
            return;

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

                            damage *= damageComponent.DamageMultiplier;

                            var realDamage = (int) Math.Round(damage);

                            var targetMaxHealth = target.Monster.Stats[Stat.Health];
                            var damagePercentage = (1 - (float) (targetMaxHealth - realDamage) / targetMaxHealth) * 100;

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
