WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

// Numatytasis maršrutas: /Valdiklis/Veiksmas/id, pradžioje atidaromas Pagrindinis langas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
