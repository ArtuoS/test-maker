using Microsoft.EntityFrameworkCore;
using TestMaker.Authentication.Domain.Entities;

namespace TestMaker.Authentication.Persistence.Context
{
    public class AuthenticationDbContext : DbContext
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
        { }

        public DbSet<Account> Accounts { get; set; }
    }
}
