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
    public Faction Faction => this.Players.Count is 0 || this.Players.First() is null ? Faction.Horde : this.Players.First().GetFaction();
    public Bracket Bracket => this.Players.Count switch
    {
        2 => Bracket.Twos,
        3 => Bracket.Threes,
        5 => Bracket.Fives,
        _ => Bracket.None,
    };
    public string Composition()
    {
        var comp = string.Empty;

        if (this.Players.Count == 0)
        {
            return comp;
        }

        foreach (var player in this.Players)
        {
            comp += $"{player.Class}/";
        }

        return comp.Remove(comp.Length - 1);
    }
}
