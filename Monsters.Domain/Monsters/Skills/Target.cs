namespace Monsters.Domain.Monsters.Skills
{
    public enum Target
    {
        None,
        Self,
        Friendly,
        FriendlyIncludingDead, // eg revive
        FriendlyDeadOnly, // eg revive
        FriendlyTeam, // eg buff
        Enemy,
        EnemyTeam,
        All,
    }
}
