using System;
using Monsters.Domain.Combat;
using Monsters.Domain.Monsters;
using Monsters.Domain.Monsters.Stats;

namespace Monsters.Console.Utils
{
    public static class DamageReporter
    {
        public static void ReportDamage(Monster attacker, Monster defender)
        {
            var attack = attacker.Stats[Stat.Attack];
            var defense = defender.Stats[Stat.Defense];
            var health = defender.Stats[Stat.Health];

            var attackMultiplier = 0.6f;

            System.Console.WriteLine($"Lv {attacker.Level} {attacker.Species.Name} ({attack} ATK) vs lv {defender.Level} {defender.Species.Name} ({defense} DEF, {defender.Stats[Stat.Health]} HP):");
            System.Console.WriteLine($"Single damaging attack with {attackMultiplier:P0} multiplier");
            System.Console.WriteLine();

            ReportHit("no buffs", attack, defense, health, attackMultiplier);
            ReportHit("-50% def break", attack, defense / 2, health, attackMultiplier);
            ReportHit("+50% atk boost", (int)Math.Round(attack * 1.5), defense, health, attackMultiplier);
            ReportHit("both", (int)Math.Round(attack * 1.5), defense / 2, health, attackMultiplier);
        }

        private static void ReportHit(
            string hitDescription,
            int attack,
            int defense,
            int health,
            float attackMultiplier
        )
        {
            var attackWithMultiplier = (int) Math.Round(attack * attackMultiplier);
            var damageDone = DamageCalculator.GetDamage(attackWithMultiplier, defense);
            var damageDonePercentage = 1 - (health - damageDone) / (float) health;
            var hitsToKill = CalculateHitsToKill(damageDone, health);

            System.Console.WriteLine($"{damageDone} dmg, {hitDescription} ({damageDonePercentage:P}, htk: {hitsToKill})");
        }

        private static int CalculateHitsToKill(int damage, int health)
        {
            return (int)Math.Ceiling((float)health / damage);
        }
    }
}
