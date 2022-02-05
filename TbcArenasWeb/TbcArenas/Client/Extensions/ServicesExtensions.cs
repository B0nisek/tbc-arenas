namespace TbcArenas.Client.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection ConfigureClients(this IServiceCollection services)
    {
        _ = services.AddScoped<IWeatherForecastClient, WeatherForecastClient>();
        _ = services.AddScoped<IArenasClient, ArenasClient>();

        return services;
    }
}
