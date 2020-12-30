namespace Monsters.Domain.Monsters.Skills.Components
{
    public class DamageComponent : Component
    {
        public int DamageMultiplier { get; set; }

        // single hit vs multi hit
        // side effects (based on chance%, like debuffs, additional hits etc)? maybe additional component on the skill?
    }
}
