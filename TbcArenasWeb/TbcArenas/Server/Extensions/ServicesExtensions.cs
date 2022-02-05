using System.Reflection;
using TbcArenas.Shared.Models;
using TbcArenas.Shared.Services.Arena;
using TbcArenas.Shared.Services.CSV;

namespace TbcArenas.Server.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        _ = services.AddAutoMapper(Assembly.GetAssembly(typeof(ArenaRecord)));
        _ = services.AddScoped<IArenaService, ArenaService>();
        _ = services.AddScoped<ICsvService, CsvService>();

        return services;
    }
}
