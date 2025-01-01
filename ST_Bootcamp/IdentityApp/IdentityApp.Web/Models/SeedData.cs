using IdentityApp.Web.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Web.Models;

public static class SeedData
{
    private const string adminUser = "admin";
    private const string adminPassword = "Admin_123";

    public static async void IdentityTestUser(IApplicationBuilder app)
    {
        var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityContext>();

        if(context.Database.GetAppliedMigrations().Any())
        {
            context.Database.Migrate();
        }

        var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();

        var user = await userManager.FindByNameAsync(adminUser);

        if(user == null)
        {
            user = new AppUser() {
                FullName = "Fırat Alçın",
                UserName = adminUser,
                Email = "admin@firatalcin.com",
                PhoneNumber = "44444444"                    
            };

            await userManager.CreateAsync(user, adminPassword);
        }
    }
}