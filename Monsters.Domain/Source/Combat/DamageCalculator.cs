using System;

namespace Monsters.Domain.Combat
{
    public static class DamageCalculator
    {
        public static int GetDamage(int attack, int defense)
        {
            return (int) Math.Ceiling((double) attack * attack / (attack + defense));
            // return (int) Math.Round(attack * (100 / (100 + (float) defense)) * 1);
        }
    }
}
