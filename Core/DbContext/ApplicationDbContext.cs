using JwtAutorizacionAutenciacionEnRoles.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JwtAutorizacionAutenciacionEnRoles.Core.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> // ApplicationUser
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
