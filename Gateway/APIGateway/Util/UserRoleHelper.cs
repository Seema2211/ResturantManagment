

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace APIGateway.Util
{
    public class UserRoleHelper
    {
        public static string GetUserRole(ClaimsIdentity identity)
        {
            IEnumerable<Claim> claims = identity.Claims;
            return claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        }
    }
}
