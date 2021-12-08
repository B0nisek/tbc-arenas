namespace TbcArenas.Shared.Models;

public enum Class { None, Warrior, Paladin, Hunter, Priest, Shaman, Mage, Warlock, Druid, Rogue }
public enum Race { None, Human, Dwarf, NightElf, Gnome, Draenei, Orc, Undead, Tauren, Troll, BloodElf }

public class PlayerRecord
{
    public string Name { get; set; }
    public Class Class { get; set; }
    public Race Race { get; set; }

    public Faction GetFaction()
    {
        return this.Race switch
        {
            Race.Human or Race.Dwarf or Race.NightElf or Race.Gnome or Race.Draenei => Faction.Alliance,
            Race.None or Race.Orc or Race.Undead or Race.Tauren or Race.Troll or Race.BloodElf => Faction.Horde,
            _ => Faction.Horde,
        };
    }

    public override bool Equals(object obj) => base.Equals(obj);
    public override int GetHashCode() => (this.Name, this.Class, this.Race).GetHashCode();
    public override string ToString() => $"{this.Name} - {this.Race} {this.Class}";
}

public static class Extensions
{
    public static Race ToRace(this string value)
    {
        return Enum.TryParse<Race>(value, ignoreCase: true, out var result)
            ? result
            : value switch
            {
                "SCOURGE" => Race.Undead,
                _ => Race.None,
            };
    }

    public static Class ToClass(this string value) => Enum.TryParse<Class>(value, ignoreCase: true, out var result) ? result : Class.None;
}