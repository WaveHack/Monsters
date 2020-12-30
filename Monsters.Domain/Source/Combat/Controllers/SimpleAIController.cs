using System.Collections.Generic;
using Monsters.Domain.Monsters.Skills;

namespace Monsters.Domain.Combat.Controllers
{
    public class SimpleAIController : Controller
    {
        public override ActiveSkill GetSkill(CombatMonster monster)
        {
            throw new System.NotImplementedException();
        }

        public override CombatMonster GetTarget(IEnumerable<CombatMonster> eligibleTargets)
        {
            throw new System.NotImplementedException();
        }
    }
}
