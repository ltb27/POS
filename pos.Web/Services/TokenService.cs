using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using pos.Users.Model;

namespace pos.Web.Services;

public interface ITokenService
{
    string GetToken(UserToken user, int expireIn = 0);
}

public class TokenService : ITokenService
{
    private readonly IOptions<TokenSettings> tokenSettings;

    public TokenService(IOptions<TokenSettings> tokenSettings)
    {
        this.tokenSettings = tokenSettings;
    }

    public string GetToken(UserToken user, int expireIn = 0)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.FullName),
            new(ClaimTypes.Role, user.Role ?? string.Empty),
            new(ClaimTypes.NameIdentifier, user.UserName ?? string.Empty)
        };
        if (expireIn == 0)
            expireIn = tokenSettings.Value.ExpireIn;
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Value.SecurityKey));

        var token = new JwtSecurityToken(tokenSettings.Value.Issuer, tokenSettings.Value.Audience, claims,
            expires:
            DateTime.Now.AddMinutes(expireIn),
            signingCredentials:
            new SigningCredentials(key, SecurityAlgorithms.Sha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}