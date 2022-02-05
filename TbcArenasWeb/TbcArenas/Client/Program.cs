using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TbcArenas.Client;
using TbcArenas.Client.Extensions;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }.EnableIntercept(sp));
builder.Services.ConfigureClients();
builder.Services.AddLoadingBar();
builder.UseLoadingBar();

await builder.Build().RunAsync();
