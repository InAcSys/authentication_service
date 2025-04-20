using AuthenticationService.Domain.DTOs;
using AuthenticationService.Domain.Entities.Concretes;

namespace AuthenticationService.Infrastructure.Repositories.Interfaces
{
    public interface ILogInRepository : IRepository<Session, Guid>
    {
        Task<string> LogIn(LogInDTO logIn);
    }
}