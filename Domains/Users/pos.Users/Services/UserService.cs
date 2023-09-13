using pos.Users.Model;

namespace pos.Users.Services;

public interface IUserService
{
    Task<bool> IsValidUserAccountAsync(UserLogin userLogin);
    UserToken GetUserTokenInfo(string userName);
}

/// <summary>
/// Check if the user is valid then login 
/// </summary>
public class UserService : IUserService
{
    public async Task<bool> IsValidUserAccountAsync(UserLogin userLogin)
    {
        await Task.Delay(1000);
        return true;
    }

    public UserToken GetUserTokenInfo(string userName)
    {
        if (string.IsNullOrEmpty(userName))
            throw new ArgumentException("User name cannot be null");

        return new UserToken { UserName = userName, Role = "User", FirstName = "Le", LastName = "Tuan Bao" };
    }
}