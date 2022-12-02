using Ansari_Website.Domain.ValueObjects;
using Ansari_Website.Infrastructure.Identity;
using ERP.DAL.Domains;
using ERP.DAL.Domains.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Ansari_Website.Infrastructure.Persistence;

public static class ApplicationDbContextSeed
{
    public static async Task SeedDefaultUserAsync(UserManager<AspNetUser> userManager, RoleManager<ApplicationRole> roleManager)
    {
        //var administratorRole = new IdentityRole("Administrator");

        //if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
        //{
        //    await roleManager.CreateAsync(administratorRole);
        //}

        //var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        //if (userManager.Users.All(u => u.UserName != administrator.UserName))
        //{
        //    await userManager.CreateAsync(administrator, "Administrator1!");
        //    await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
        //}
    }

    public static async Task SeedSampleDataAsync(ApplicationDbContext context)
    {
        // Seed, if necessary
        
    }
}
