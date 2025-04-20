using AuthenticationService.Application.Services.Interfaces;
using AuthenticationService.Domain.DTOs;
using AuthenticationService.Domain.Entities.Concretes;
using AuthenticationService.Infrastructure.Repositories.Interfaces;
using FluentValidation;

namespace AuthenticationService.Application.Services.Abstracts
{
    public abstract class SessionAbstractService : Service<Session, Guid>, ILogInService
    {
        protected readonly ILogInRepository _logInRepository;
        protected SessionAbstractService(IValidator<Session> validator, IRepository<Session, Guid> repository, ILogInRepository logInRepository) : base(validator, repository)
        {
            _logInRepository = logInRepository;
        }

        public async Task<string> LogIn(LogInDTO logIn)
        {
            return await _logInRepository.LogIn(logIn);
        }
    }
}