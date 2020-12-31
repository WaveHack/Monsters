namespace Monsters.Domain.Monsters.Skills.Components
{
    public class DamageComponent : Component
    {
        public float DamageMultiplier { get; }

        public DamageComponent(float damageMultiplier)
        {
            DamageMultiplier = damageMultiplier;
        }
    }
}
