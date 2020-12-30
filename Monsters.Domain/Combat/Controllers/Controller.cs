using System.Collections.Generic;
using Monsters.Domain.Monsters.Skills;

namespace Monsters.Domain.Combat.Controllers
{
    public abstract class Controller
    {
        public abstract ActiveSkill GetSkill(CombatMonster monster);

        public abstract CombatMonster GetTarget(IEnumerable<CombatMonster> eligibleTargets);
    }
}
