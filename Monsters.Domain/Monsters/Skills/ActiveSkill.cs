using System.Collections.Generic;
using Monsters.Domain.Monsters.Skills.Components;

namespace Monsters.Domain.Monsters.Skills
{
    public class ActiveSkill : Skill
    {
        public Target Target { get; }
        public int Cooldown { get; }
        public List<Component> Components { get; } = new();

        public ActiveSkill(string name, Target target, int cooldown = 0)
        {
            Name = name;
            Target = target;
            Cooldown = cooldown;
        }
    }
}
