using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TbcArenas.Server.Data;
using TbcArenas.Server.Models;
using TbcArenas.Shared.Models;
using TbcArenas.Shared.Services.Arena;
using TbcArenas.Shared.Services.CSV;

namespace TbcArenas.Server.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection ConfigureDb(this IServiceCollection services, string connectionString)
    {
        _ = services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        _ = services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }

    public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddIdentityServer().AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        return services;
    }

    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetAssembly(typeof(ArenaRecord)));
        services.AddScoped<IArenaService, ArenaService>();
        services.AddScoped<ICsvService, CsvService>();

        return services;
    }
}
