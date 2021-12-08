namespace TbcArenas.Shared.Models;

public enum Class { None, Warrior, Paladin, Hunter, Priest, Shaman, Mage, Warlock, Druid, Rogue }
public enum Race { None, Human, Dwarf, NightElf, Gnome, Draenei, Orc, Undead, Tauren, Troll, BloodElf }

public class PlayerRecord
{
    public string Name { get; set; }
    public Class Class { get; set; }
    public Race Race { get; set; }
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