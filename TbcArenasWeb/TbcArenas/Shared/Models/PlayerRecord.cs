namespace TbcArenas.Shared.Models;

public enum Class { None, Warrior, Paladin, Hunter, Priest, Shaman, Mage, Warlock, Druid, Rogue }
public enum Race { None, Human, Dwarf, NightElf, Gnome, Draenei, Orc, Undead, Tauren, Troll, BloodElf }

public class PlayerRecord
{
    public string Name { get; set; }
    public Class Class { get; set; }
    public Race Race { get; set; }
}
