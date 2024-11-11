using BusinessLogicLayer.ServiceRegistrations;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.ServiceRegistrations;
using Microsoft.AspNetCore.Identity;
using MVCMiniProject.DataAccessLayer;
namespace MVCMiniProject;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddDataAccessServices(builder.Configuration);
        builder.Services.AddBusinessServices();




        builder.Services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDBContext>()
            .AddDefaultTokenProviders();

        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Account/AccessDenied";
        });



        var app = builder.Build();


        using (var scope = app.Services.CreateScope())
        {
            var dbInitializer = scope.ServiceProvider.GetRequiredService<DBInitializer>();
            await dbInitializer.SeedDataAsync();
        }

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        await app.RunAsync();
    }
}
