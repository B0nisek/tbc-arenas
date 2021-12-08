using AutoMapper;
using System.Reflection;
using TbcArenas.Shared.Models;

namespace TbcArenas.Tests.Fixtures;

public static class AutoMapperTestFixture
{
    public static IMapper GetMapper()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddMaps(Assembly.GetAssembly(typeof(ArenaRecord))));

        return configuration.CreateMapper();
    }
}
