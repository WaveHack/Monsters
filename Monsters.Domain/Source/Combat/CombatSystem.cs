using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Monsters.Domain.Combat.Controllers;
using Monsters.Domain.Monsters;
using Monsters.Domain.Monsters.Stats;

namespace Monsters.Domain.Combat
{
    public class CombatSystem
    {
        public List<CombatMonster> PlayerTeam { get; }
        public List<CombatMonster> EnemyTeam { get; private set; }
        public bool IsInProgress { get; private set; }

        public int Ticks { get; set; }
        public int CurrentTurn { get; set; }

        public List<CombatMonster> AllMonsters =>
            new List<CombatMonster>(PlayerTeam)
                .Concat(EnemyTeam)
                .ToList();

        public CombatSystem(IEnumerable<Monster> playerTeam, Controller playerController)
        {
            PlayerTeam = GenerateCombatTeam(playerTeam, playerController);
        }

        public void InitiateCombat(IEnumerable<Monster> enemyTeam, Controller enemyController)
        {
            EnemyTeam = GenerateCombatTeam(enemyTeam, enemyController);
            IsInProgress = true;
        }

        public void Tick()
        {
            foreach (var monster in AllMonsters)
            {
                // Increase ATB
                monster.AttackBar += .07f * monster.CurrentStats[Stat.Speed];
            }

            Ticks++;
        }

        public CombatMonster GetNextActiveMonster()
        {
            var activeMonsters = AllMonsters
                .Where(m => m.IsAlive)
                .Where(m => m.AttackBar >= 100)
                .ToList();

            if (!activeMonsters.Any())
                return null;

            return activeMonsters
                .OrderByDescending(m => m.AttackBar)
                .First();
        }

        private static List<CombatMonster> GenerateCombatTeam(IEnumerable<Monster> monsters, Controller controller)
        {
            var combatMonsters = new List<CombatMonster>();

            var i = 1;
            foreach (var monster in monsters)
            {
                combatMonsters.Add(new CombatMonster
                {
                    Index = i,
                    Controller = controller,
                    Monster = monster,
                    CurrentStats = new Dictionary<Stat, int>(monster.Stats),
                    AttackBar = 0,
                });

                i++;
            }

            return combatMonsters;
        }
    }
}
