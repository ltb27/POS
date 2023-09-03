using pos.Users.Model;

namespace pos.Users.Services;

public interface IUserService
{
    Task<bool> IsValidUserAccountAsync(UserLogin userLogin);
}

/// <summary>
/// Check if the user is valid then login 
/// </summary>
public class UserService : IUserService
{
    public UserService()
    {
    }

    public async Task<bool> IsValidUserAccountAsync(UserLogin userLogin)
    {
        await Task.Delay(1000);
        return true;
    }
}