using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimsPricipleExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            //Claim Type: Can refer back to TokenServices JwtRegisteredClaimNames
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }
        public static int GetUserId(this ClaimsPrincipal user)
        {
            //Claim Type: Can refer back to TokenServices JwtRegisteredClaimNames
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}