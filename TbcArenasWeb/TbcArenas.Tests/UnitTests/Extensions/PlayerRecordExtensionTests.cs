using TbcArenas.Shared.Models;
using Xunit;

namespace TbcArenas.Tests.UnitTests.Extensions;

public class PlayerRecordExtensionTests
{
    [Theory]
    [InlineData("DWARF", Race.Dwarf)]
    [InlineData("SCOURGE", Race.Undead)]
    [InlineData("SHIT", Race.None)]
    public void String_ReturnsCorrectRace(string value, Race expectedRace)
    {
        var result = value.ToRace();

        Assert.Equal(expectedRace, result);
    }

    [Theory]
    [InlineData("SHIT", Class.None)]
    [InlineData("WARRIOR", Class.Warrior)]
    [InlineData("PALADIN", Class.Paladin)]
    [InlineData("HUNTER", Class.Hunter)]
    [InlineData("PRIEST", Class.Priest)]
    [InlineData("SHAMAN", Class.Shaman)]
    [InlineData("MAGE", Class.Mage)]
    [InlineData("WARLOCK", Class.Warlock)]
    [InlineData("DRUID", Class.Druid)]
    [InlineData("ROGUE", Class.Rogue)]
    public void String_ReturnsCorrectClass(string value, Class expectedClass)
    {
        var result = value.ToClass();

        Assert.Equal(expectedClass, result);
    }
}
