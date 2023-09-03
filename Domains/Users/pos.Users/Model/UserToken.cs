using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace pos.Users.Model;

public class UserToken
{
    public string? UserName { get; set; }
    public string? Role { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public string FullName => FirstName + " " + LastName;
}