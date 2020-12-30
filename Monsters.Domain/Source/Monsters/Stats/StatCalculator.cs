using System;

namespace Monsters.Domain.Monsters.Stats
{
    public static class StatCalculator
    {
        public static int CalculateMonsterStat(Monster monster, Stat stat)
        {
            if (IsSecondaryStat(stat))
                return monster.Species.Stats[stat];

            var levelModifier = 10 + monster.Level;

            var statMultiplier = stat switch
            {
                Stat.Health => levelModifier * 2f,
                Stat.Attack => levelModifier / 2f,
                Stat.Defense => levelModifier / 2f,
                _ => throw new ArgumentOutOfRangeException(nameof(stat), stat, null)
            };

            var baseStat = monster.Species.Stats[stat];

            return (int) Math.Round(baseStat * statMultiplier);
        }

        public static bool IsPrimaryStat(Stat stat)
        {
            switch (stat)
            {
                case Stat.Health:
                case Stat.Attack:
                case Stat.Defense:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsSecondaryStat(Stat stat)
        {
            switch (stat)
            {
                case Stat.Speed:
                case Stat.Accuracy:
                case Stat.Resistance:
                case Stat.CriticalRate:
                case Stat.CriticalDamage:
                    return true;
                default:
                    return false;
            }
        }
    }
}
