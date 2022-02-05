using TbcArenas.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddOpenApiDocument(cfg => cfg.Title = "TbcArenas API");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    _ = app.UseExceptionHandler("/Error");
    _ = app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseSwaggerUi3(cfg => cfg.DocumentPath = "/api/v1/specification.json");

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
