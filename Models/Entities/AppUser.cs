using Microsoft.AspNetCore.Identity;

namespace Models;

public class AppUser : IdentityUser
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime DateOfBirth { get; set; }
    
    public static AppUser GetSeedUser()
    {
        return new AppUser
        {
            Email = "nickglas@hotmail.nl",
            UserName = "nick"
        };
    }
}