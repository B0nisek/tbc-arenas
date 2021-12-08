namespace TbcArenas.Shared.Models;

public enum Faction { Horde, Alliance }

public class TeamRecord
{
    public int Mmr { get; set; }
    public int Rating { get; set; }
    public string Name { get; set; }
    public HashSet<PlayerRecord> Players { get; set; } = new();
    public Faction Faction => this.Players.First() == null ? Faction.Horde : this.Players.First().GetFaction();
}
