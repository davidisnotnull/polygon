using Microsoft.EntityFrameworkCore;
using Polygon.App.Data;
using Polygon.App.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Data initialisation

builder.Services.AddDbContext<PolygonDbContext>(options =>
{
    options.UseInMemoryDatabase(Guid.NewGuid().ToString());
#if DEBUG
    options.EnableSensitiveDataLogging();
    options.EnableDetailedErrors();
#endif
});

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IPolygonDbContext, PolygonDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();