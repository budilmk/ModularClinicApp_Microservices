namespace Authentication.API.Security;

// Create JwtConfig class 
public record JwtOptions
{
    public static string SectionName = "Jwt";
    public string Issuer { get; set; } = String.Empty;
    public string Secret { get; set; } = String.Empty;
}
