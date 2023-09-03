using Microsoft.VisualBasic;

namespace pos.Core.Settings;

public class TokenSettings
{
    public string SecurityKey { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
}