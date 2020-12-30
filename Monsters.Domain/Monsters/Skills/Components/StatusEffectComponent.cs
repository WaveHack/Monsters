namespace Monsters.Domain.Monsters.Skills.Components
{
    public class StatusEffectComponent : Component
    {
        public int ChanceToApply { get; set; } = 100;

        public StatusEffect StatusEffect { get; set; }

        public int AmountOfTurns { get; set; } = 1;
    }
}
