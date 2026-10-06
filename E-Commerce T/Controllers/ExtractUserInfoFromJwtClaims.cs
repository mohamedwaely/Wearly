using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace E_Commerce_T.Extensions
{
    public static class ExtractUserInfoFromJwtClaims
    {
        public static long GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

            if (userIdClaim is null || !long.TryParse(userIdClaim, out var userId))
            {
                throw new UnauthorizedAccessException("User ID not found in token.");
            }

            return userId;
        }
    }
}