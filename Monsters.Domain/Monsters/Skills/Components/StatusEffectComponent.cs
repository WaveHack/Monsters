namespace Monsters.Domain.Monsters.Skills.Components
{
    public class StatusEffectComponent : Component
    {
        public StatusEffect StatusEffect { get; }
        public float ChanceToApply { get; }
        public int AmountOfTurns { get; }

        public StatusEffectComponent(StatusEffect statusEffect, float chanceToApply, int amountOfTurns = 2)
        {
            StatusEffect = statusEffect;
            ChanceToApply = chanceToApply;
            AmountOfTurns = amountOfTurns;
        }
    }
}
