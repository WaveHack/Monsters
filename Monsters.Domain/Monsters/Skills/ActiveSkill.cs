using System.Collections.Generic;
using Monsters.Domain.Monsters.Skills.Components;

namespace Monsters.Domain.Monsters.Skills
{
    public class ActiveSkill : Skill
    {
        private const int DefaultCooldown = 0;

        public Target Target { get; }
        public int Cooldown { get; }
        public List<Component> Components { get; } = new();

        public ActiveSkill(string name, Target target, int cooldown = DefaultCooldown)
        {
            Name = name;
            Target = target;
            Cooldown = cooldown;
        }
    }
}
