namespace Monsters.Domain.Monsters.Skills
{
    public enum StatusEffect
    {
        AttackBoost, // +50%
        AttackBreak, // -50%
        DefenseBoost, // +50%
        DefenseBreak, // -70%
        SpeedBoost, // +30%
        SpeedBreak, // -30%
        CriticalRateBoost, // +30%

        Immunity,
        BlockBeneficialEffects,

        Poison,
        ContinuousDamage, // 5%

        Invincibility,
        Defend,
        Endure,
        Revenge, // 50%
        Recovery, // 15%
        Counter, // 100%
        ProtectSoul,
        Reflect, // 33%
        CriticalRateResist, // -50%
        Shield,
        Glancing, // +50%
        Brand, // +25%
        Unrecoverable,
        Taunt,
        Oblivion,
        Bomb,
        Freeze,
        Stun,
        Sleep,
        Silence,
    }
}
