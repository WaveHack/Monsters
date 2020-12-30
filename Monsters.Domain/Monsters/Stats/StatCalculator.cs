using System;

namespace Monsters.Domain.Monsters.Stats
{
    public static class StatCalculator
    {
        private const int LevelModifierOffset = 10;

        public static int CalculateMonsterStat(Monster monster, Stat stat)
        {
            if (IsPrimaryStat(stat))
                return CalculateMonsterPrimaryStat(monster, stat);

            if (IsSecondaryStat(stat))
                return monster.Species.Stats[stat];

            throw new ArgumentOutOfRangeException(nameof(stat), stat, null);
        }

        private static int CalculateMonsterPrimaryStat(Monster monster, Stat stat)
        {
            var levelModifier = monster.Level + LevelModifierOffset;

            var statMultiplier = stat switch
            {
                Stat.Health => levelModifier * 2f,
                Stat.Attack => levelModifier / 2f,
                Stat.Defense => levelModifier / 2f,
                _ => throw new ArgumentOutOfRangeException(nameof(stat), stat, $"{stat} is not a primary stat")
            };

            var baseStat = monster.Species.Stats[stat];

            return (int) Math.Round(baseStat * statMultiplier);
        }

        private static bool IsPrimaryStat(Stat stat)
        {
            return stat switch
            {
                Stat.Health => true,
                Stat.Attack => true,
                Stat.Defense => true,
                _ => false
            };
        }

        private static bool IsSecondaryStat(Stat stat)
        {
            return stat switch
            {
                Stat.Speed => true,
                Stat.Accuracy => true,
                Stat.Resistance => true,
                Stat.CriticalRate => true,
                Stat.CriticalDamage => true,
                _ => false
            };
        }
    }
}
