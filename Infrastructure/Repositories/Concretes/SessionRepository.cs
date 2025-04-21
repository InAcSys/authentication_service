using AuthenticationService.Domain.Entities.Concretes;
using AuthenticationService.Infrastructure.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Infrastructure.Repositories.Concretes
{
    public class SessionRepository : SessionAbstractRepository
    {
        public SessionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}