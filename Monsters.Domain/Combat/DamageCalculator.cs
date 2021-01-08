using System;

namespace Monsters.Domain.Combat
{
    public static class DamageCalculator
    {
        private const int DefenseOffset = 100;

        public static int GetDamage(int attack, int defense)
        {
            return (int) Math.Round(attack * (DefenseOffset / (DefenseOffset + (float) defense)));
        }
    }
}
