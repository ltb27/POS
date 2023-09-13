using System.ComponentModel.DataAnnotations;

namespace pos.Users.Model;

public class UserLogin
{
    [Required] public string? UserName { get; set; } = string.Empty;
    [Required] public string? Password { get; set; } = string.Empty;
}