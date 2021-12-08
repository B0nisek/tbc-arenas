namespace TbcArenas.Shared.Models;

public enum Faction { Horde, Alliance }

public class TeamRecord
{
    public int Mmr { get; set; }
    public int Rating { get; set; }
    public string Name { get; set; }
    public IEnumerable<PlayerRecord> Players { get; set; } = new List<PlayerRecord>();
    public Faction Faction { get; set; }
}
