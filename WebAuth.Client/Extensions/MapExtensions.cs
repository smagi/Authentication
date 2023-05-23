using WebAuth.Client.Models;
using WebAuth.Api.Contracts.Dtos.Login;

namespace WebAuth.Client.Extensions;

public static class MapExtensions
{
    public static TokenDto MapToDto(this Token token)
    {
        return new TokenDto();
    }
}
