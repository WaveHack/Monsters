using System.Collections.Generic;
using Monsters.Domain.Monsters.Skills.Components;

namespace Monsters.Domain.Monsters.Skills
{
    public class ActiveSkill : Skill
    {
        public int Cooldown { get; set; }

        public Target Target { get; set; }

        public List<Component> Components { get; set; }
    }
}
