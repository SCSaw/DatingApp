using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimsPricipleExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            //Claim Type: Can refer back to TokenServices JwtRegisteredClaimNames
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}