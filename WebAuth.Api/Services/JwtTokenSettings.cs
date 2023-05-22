namespace WebAuth.Api.Services
{
    public class JwtTokenSettings
    { 
        public string? ValidAudience { get; init; }
        public string? ValidIssuer { get; init; }
        public string? Secret { get; init; }
        public int ExpiryInMinutes { get; init; }
    }
}