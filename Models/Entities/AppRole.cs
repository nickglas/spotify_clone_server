using Microsoft.AspNetCore.Identity;

namespace Models;

public class AppRole : IdentityRole
{
    public string Description { get; set; }
    public DateTime AddedAt { get; set; } = DateTime.Now;

    public static List<AppRole> GetSeedRoles()
    {
        return new List<AppRole>
        {
            new AppRole
            {
                Name = "User",
                Description = "Default role"
            },
            new AppRole
            {
                Name = "Admin",
                Description = "Admin role"
            }
        };
    }

}