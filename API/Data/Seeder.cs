using Microsoft.AspNetCore.Identity;
using Models;

namespace API.Data;

public class Seeder
{
    public async Task SeedRolesAsync(RoleManager<AppRole> roleManager)
    {
        foreach (var role in AppRole.GetSeedRoles())
        {
            if (!await roleManager.RoleExistsAsync(role.Name))
            {
                await roleManager.CreateAsync(role);
            }
        }
    }
}