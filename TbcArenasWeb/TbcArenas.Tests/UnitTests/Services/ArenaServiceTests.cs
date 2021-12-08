using System.Collections.Generic;
using TbcArenas.Shared.Models;
using TbcArenas.Shared.Services.Arena;
using TbcArenas.Tests.Fixtures;
using Xunit;

namespace TbcArenas.Tests.UnitTests.Services;

public class ArenaServiceTests
{
    private readonly IArenaService arenaService;
    private readonly List<ArenaCsvRecord> arenaCsvRecords;

    public ArenaServiceTests()
    {
        var mapper = AutoMapperTestFixture.GetMapper();
        this.arenaService = new ArenaService(mapper);
        this.arenaCsvRecords = GenerateArenaCsvRecords();
    }

    [Fact]
    public void ArenaService_CorrectlyMapsCsvRecords()
    {
        var result = this.arenaService.Some(this.arenaCsvRecords);

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
        }
    };
}
