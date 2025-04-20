using AuthenticationService.Domain.DTOs;
using AuthenticationService.Domain.Entities.Concretes;

namespace AuthenticationService.Application.Services.Interfaces
{
    public interface ILogInService : IService<Session, Guid>
    {
        Task<string> LogIn(LogInDTO logIn);
    }
}