using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monsters.Domain.Monsters.Skills;

namespace Monsters.Domain.Combat.Controllers
{
    public class LocalPlayerController : Controller
    {
        public override ActiveSkill GetSkill(CombatMonster monster)
        {
            var allActiveSkills = monster.Monster.Species.Skills
                .Where(s => s is ActiveSkill)
                .ToList();

            var sb = new StringBuilder();

            sb.AppendLine(monster.ToString());

            var i = 1;
            foreach (var skill in allActiveSkills)
            {
                var activeSkill = (ActiveSkill) skill;
                // var isOnCooldown = activeSkill.Cooldown > 0;

                sb.Append($"[{i}] {activeSkill.Name} - {activeSkill.Description}");

                // if (isOnCooldown)
                    // sb.Append(" [on cooldown]");

                sb.AppendLine();

                i++;
            }

            Console.Write(sb);

            Console.Write("> ");
            var input = Console.ReadLine();
            Console.WriteLine();

            if (!int.TryParse(input, out var skillIndex))
                throw new Exception("Invalid input");

            return allActiveSkills[skillIndex - 1] as ActiveSkill;
        }

        public override CombatMonster GetTarget(IEnumerable<CombatMonster> eligibleTargets)
        {
            var combatMonsters = eligibleTargets.ToList();
            var sb = new StringBuilder();

            sb.AppendLine("Select target:");

            foreach (var monster in combatMonsters)
                sb.AppendLine($"[{monster.Index}]: {monster}");

            Console.Write(sb);

            Console.Write("> ");
            var input = Console.ReadLine();
            Console.WriteLine();

            if (!int.TryParse(input, out var monsterIndex))
                throw new Exception("Invalid input");

            return combatMonsters
                .First(m => m.Index == monsterIndex);
        }
    }
}
