namespace Monsters.Domain.Monsters.Skills.Components
{
    public class StatusEffectComponent : Component
    {
        private const float DefaultChanceToApply = 1f;
        private const int DefaultAmountOfTurns = 2;

        public StatusEffect StatusEffect { get; }
        public float ChanceToApply { get; }
        public int AmountOfTurns { get; }

        public StatusEffectComponent(
            StatusEffect statusEffect,
            float chanceToApply = DefaultChanceToApply,
            int amountOfTurns = DefaultAmountOfTurns
        )
        {
            StatusEffect = statusEffect;
            ChanceToApply = chanceToApply;
            AmountOfTurns = amountOfTurns;
        }
    }
}
