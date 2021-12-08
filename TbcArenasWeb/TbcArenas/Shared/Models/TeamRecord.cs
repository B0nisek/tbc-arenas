namespace TbcArenas.Shared.Models;

public enum Faction { Horde, Alliance }
public enum Bracket 
{ 
    None = 0,
    Twos = 2, 
    Threes = 3, 
    Fives = 5 
}

public class TeamRecord
{
    public int Mmr { get; set; }
    public int Rating { get; set; }
    public string Name { get; set; }
    public HashSet<PlayerRecord> Players { get; set; } = new();
    public Faction Faction => this.Players.First() is null ? Faction.Horde : this.Players.First().GetFaction();
    public Bracket Bracket => (Bracket)this.Players.Count;
}
