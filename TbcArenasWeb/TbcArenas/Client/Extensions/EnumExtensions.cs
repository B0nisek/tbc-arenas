using TbcArenas.Shared.Models;

namespace TbcArenas.Client.Extensions;
public static class EnumExtensions
{
    public static string ZoneToString(this Zone zone) =>
        zone switch
        {
            Zone.RuinsOfLordaeron => "Ruins",
            Zone.RuinsOfLordaeron2 => "Ruins",
            Zone.BladesEdgeMountains => "Blade's Edge",
            Zone.BladesEdgeMountains2 => "Blade's Edge",
            Zone.Nagrand => "Nagrand",
            Zone.Nagrand2 => "Nagrand",
            _ => zone.ToString()
        };
}
