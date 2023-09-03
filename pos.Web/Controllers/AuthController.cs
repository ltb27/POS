using Microsoft.AspNetCore.Mvc;
using pos.Users.Model;
using pos.Users.Services;

namespace pos.Web.Controllers;

public class AuthController : ApplicationBaseController
{
    private readonly IUserService userService;

    public AuthController(ILogger<AuthController> logger, IUserService userService) : base(logger)
    {
        this.userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLogin userInfo)
    {
        var result = await userService.IsValidUserAccountAsync(userInfo);
        if (!result)
            return BadRequest(new
            {
                statusCode = "invalid_user_account"
            });
        // create token
        const string token = "";
        return Ok(token);
    }
}