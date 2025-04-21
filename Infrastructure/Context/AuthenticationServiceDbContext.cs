using AuthenticationService.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Infrastructure.Context
{
    public class AuthenticationServiceDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Session> Sessions { get; set; }
    }
}