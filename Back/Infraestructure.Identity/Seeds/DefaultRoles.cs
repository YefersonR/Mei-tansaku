using Infraestructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Application.Enum;

namespace Infraestructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task Seed(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Owner.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
        }
    }
}
