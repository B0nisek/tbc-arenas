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
    public void Test()
    {
        var result = this.arenaService.Some(this.arenaCsvRecords);

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    private static List<ArenaCsvRecord> GenerateArenaCsvRecords() => new()
    {

    };
}
