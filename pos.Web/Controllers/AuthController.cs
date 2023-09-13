using Microsoft.AspNetCore.Authorization;
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

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLogin userInfo)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = await userService.IsValidUserAccountAsync(userInfo);
        if (!result)
            return BadRequest(new
            {
                statusCode = "invalid_user_account"
            });

        // create token
        var userToken = userService.GetUserTokenInfo(userInfo.UserName ?? string.Empty);

        var token = tokenService.GetToken(
            userToken, 60);

        return Ok(token);
    }
}