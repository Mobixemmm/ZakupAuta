using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ZakupAuta.Infrastructure.Extensions;
using ZakupAuta.Infrastructure.Persistence;
using ZakupAuta.Infrastructure.Seeders;
using ZakupAuta.Application.Extensions;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Rejestracja us³ug
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();


// Rejestracja ZakupAutaSeeder w DI
builder.Services.AddScoped<ZakupAutaSeeder>();

// Budowanie aplikacji
var app = builder.Build();

// U¿ycie ZakupAutaSeeder do inicjalizacji danych
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<ZakupAutaSeeder>();
    await seeder.Seed();
}

// Konfiguracja potoku HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Uwierzytelnianie
app.UseAuthorization();  // Autoryzacja

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();