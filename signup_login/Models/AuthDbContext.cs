using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace signup_login.Models
{
    //AuthDbContext Extends Identity's
    //Used to Link the Application to the Database
    public class AuthDbContext: IdentityDbContext
    {
        //constructor
        //DbContextOptions comes from Microsoft.EntityFrameworkCore
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }
    }
}