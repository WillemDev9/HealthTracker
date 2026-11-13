using Health.UI.Components;
using Health.Data;
using Health.Core.Interfaces;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var dbPath = Path.Combine(builder.Environment.ContentRootPath, "Fitness.db");
builder.Services.AddDbContext<FitnessDB>(options => options.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddScoped<IFitnessRepository, FitnessRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FitnessDB>();
    db.Database.EnsureCreated();

    if(!db.BodyMetricLogs.Any())
    {
        await BodyMetricCSVImporter.ImportBodyMetricHistory(db, app.Environment.ContentRootPath);
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
