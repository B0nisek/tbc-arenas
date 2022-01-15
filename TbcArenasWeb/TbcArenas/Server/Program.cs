using Microsoft.EntityFrameworkCore;
using TbcArenas.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureDb(builder.Configuration.GetConnectionString("DefaultConnection"));
//builder.Services.ConfigureIdentity();
//builder.Services.AddAuthentication()
//    .AddIdentityServerJwt();

builder.Services.ConfigureServices();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddOpenApiDocument();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseOpenApi();
app.UseSwaggerUi3();

app.UseRouting();

//app.UseIdentityServer();
//app.UseAuthentication();
//app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
