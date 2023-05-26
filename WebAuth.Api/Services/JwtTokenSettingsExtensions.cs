namespace WebAuth.Api.Services;

public static class JwtTokenSettingsExtensions
{
    public static byte[] GetSecretBytes(this JwtTokenSettings jwtTokenSettings)
    {
        return System.Text.Encoding.UTF8.GetBytes(jwtTokenSettings.Secret!);
    }
}