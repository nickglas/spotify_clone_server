using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TestController : BaseController
{

    [HttpPost]
    public async Task<IActionResult> TestPost()
    {
        Console.WriteLine("Called");
        return Created("api/test", null);
    }
    
}