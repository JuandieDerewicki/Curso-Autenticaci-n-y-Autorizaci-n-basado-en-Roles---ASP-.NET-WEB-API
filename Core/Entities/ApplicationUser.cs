using Microsoft.AspNetCore.Identity;

namespace JwtAutorizacionAutenciacionEnRoles.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
