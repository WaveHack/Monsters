namespace Monsters.Domain.Monsters.Skills
{
    public enum Target
    {
        // None,
        Self,
        Friendly,
        // FriendlyIncludingDead, // revive
        // FriendlyDeadOnly, // revive
        FriendlyTeam,
        Enemy,
        EnemyTeam,
        AllTeams,
    }
}
