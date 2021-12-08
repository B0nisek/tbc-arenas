using System.Collections.Generic;
using System.Linq;
using TbcArenas.Shared.Models;
using TbcArenas.Shared.Services.Arena;
using TbcArenas.Tests.Fixtures;
using Xunit;

namespace TbcArenas.Tests.UnitTests.Services;

public class ArenaServiceTests
{
    private readonly IArenaService arenaService;

    public ArenaServiceTests()
    {
        var mapper = AutoMapperTestFixture.GetMapper();
        this.arenaService = new ArenaService(mapper);
    }

    [Fact]
    public void ArenaService_CorrectlyMapsCsvRecords()
    {
        var result = this.arenaService.MapCsvRecords(GenerateArenaCsvRecords());

        Assert.NotNull(result);

        var mappedArenaRecord = Assert.Single(result);

        Assert.True(mappedArenaRecord.IsRanked);
        Assert.Equal(9, mappedArenaRecord.Duration.Minutes);
        Assert.Equal(28, mappedArenaRecord.Duration.Seconds);
        Assert.Equal(2021, mappedArenaRecord.StartTime.Year);
        Assert.Equal(7, mappedArenaRecord.StartTime.Day);
        Assert.Equal(12, mappedArenaRecord.StartTime.Month);
        Assert.Equal(2021, mappedArenaRecord.EndTime.Year);
        Assert.Equal(7, mappedArenaRecord.EndTime.Day);
        Assert.Equal(12, mappedArenaRecord.EndTime.Month);
        Assert.Equal(Zone.RuinsOfLordaeron, mappedArenaRecord.Zone);

        var team = mappedArenaRecord.Team;

        AssertTeam(team, "giga bIasters", Faction.Horde);
        AssertPlayer(team, "Bonisek", Race.BloodElf, Class.Paladin);
        AssertPlayer(team, "Shamazingx", Race.Orc, Class.Shaman);

        var enemyTeam = mappedArenaRecord.EnemyTeam;

        AssertTeam(enemyTeam, "Coming soon", Faction.Alliance);
        AssertPlayer(enemyTeam, "Wakaliwood", Race.NightElf, Class.Druid);
        AssertPlayer(enemyTeam, "Tebatusasula", Race.Human, Class.Rogue);
    }

    private static void AssertTeam(TeamRecord team, string teamName, Faction faction)
    {
        Assert.NotNull(team);
        Assert.Equal(teamName, team.Name);
        Assert.Equal(faction, team.Faction);
        Assert.NotNull(team.Players);
        Assert.NotEmpty(team.Players);
        Assert.Equal(2, team.Players.Count);
        Assert.Equal(Bracket.Twos, team.Bracket);
    }

    private static void AssertPlayer(TeamRecord team, string playerName, Race race, Class @class)
    {
        var player = Assert.Single(team.Players.Where(x => x.Name == playerName));

        Assert.NotNull(player);
        Assert.Equal(race, player.Race);
        Assert.Equal(@class, player.Class);
    }

    private static List<ArenaCsvRecord> GenerateArenaCsvRecords() => new()
    {
        new ArenaCsvRecord
        {
            IsRanked = "YES",
            Duration = 568,
            StartTime = "1638905722",
            EndTime = "1638906290",
            ZoneId = 3968,
            TeamName = "giga bIasters",
            Mmr = 2200,
            OldTeamRating = 2189,
            TeamPlayerName1 = "Bonisek",
            TeamPlayerClass1 = "PALADIN",
            TeamPlayerRace1 = "BloodElf",
            TeamPlayerName2 = "Shamazingx",
            TeamPlayerClass2 = "SHAMAN",
            TeamPlayerRace2 = "Orc",
            EnemyTeamName = "Coming soon",
            EnemyPlayerName1 = "Wakaliwood",
            EnemyPlayerClass1 = "DRUID",
            EnemyPlayerRace1 = "NIGHTELF",
            EnemyPlayerName2 = "Tebatusasula",
            EnemyPlayerClass2 = "ROGUE",
            EnemyPlayerRace2 = "HUMAN"
        }
    };
}
