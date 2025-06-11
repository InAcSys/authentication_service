using AuthenticationService.Application.Services.Interfaces;
using AuthenticationService.Application.Utils;
using AuthenticationService.Domain.DTOs;
using AuthenticationService.Domain.Entities.Concretes;
using AuthenticationService.Infrastructure.Repositories.Interfaces;
using FluentValidation;

namespace AuthenticationService.Application.Services.Abstracts
{
    public abstract class SessionAbstractService : Service<Session, Guid>, ILogInService
    {
        private readonly Destokenizer _destokenizer = new Destokenizer();

        protected readonly ILogInRepository _logInRepository;
        protected SessionAbstractService(IValidator<Session> validator, IRepository<Session, Guid> repository, ILogInRepository logInRepository) : base(validator, repository)
        {
            _logInRepository = logInRepository;
        }

        public async Task<string> LogIn(LogInDTO logIn)
        {
            return await _logInRepository.LogIn(logIn);
        }

        public JWTValidateDTO Validate(string jwt)
        {
            var result = _destokenizer.GetData(jwt);
            return result;
        }
    }
}