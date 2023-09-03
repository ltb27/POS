using Microsoft.AspNetCore.Mvc;
using pos.Users.Model;
using pos.Users.Services;
using pos.Web.Services;

namespace pos.Web.Controllers;

public class AuthController : ApplicationBaseController
{
    private readonly IUserService userService;
    private readonly ITokenService tokenService;

    public AuthController(ILogger<AuthController> logger, IUserService userService, ITokenService tokenService) :
        base(logger)
    {
        this.userService = userService;
        this.tokenService = tokenService;
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
        var token = tokenService.GetToken(
            new UserToken { UserName = userInfo.UserName, Role = "user", FirstName = "John", LastName = "Doe" }, 60);

        return Ok(token);
    }
}