using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOS;

namespace API.Controllers;

public class UsersController : BaseController
{

    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<AppRole> _roleManager;

    public UsersController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterTest([FromBody] RegisterDTO registerDto)
    {

        AppUser user = new AppUser
        {
            Email = registerDto.Email,
            Firstname = registerDto.Firstname,
            Lastname = registerDto.Lastname,
            UserName = registerDto.Username,
            DateOfBirth = registerDto.DateOfBirth
        };
        
        await _userManager.AddPasswordAsync(user, registerDto.Password);
        await _userManager.CreateAsync(user);
        await _userManager.AddToRoleAsync(user, "user");
        return Created("/api/users", user);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginTest([FromBody] LoginDTO loginDto)
    {

        Console.WriteLine(loginDto.Identifier);
        Console.WriteLine(loginDto.Password);

        var result = await _signInManager.PasswordSignInAsync(loginDto.Identifier, loginDto.Password, false, false);

        if (result.Succeeded)
        {
            Console.WriteLine("User " + loginDto.Identifier + " logged in successfully");
            AppUser user = await _userManager.FindByNameAsync(loginDto.Identifier);
            Console.WriteLine("User logged in with id: " + user.Id);
            return Created("/api/users/login", user);
        }

        return Unauthorized();
    }
    
}