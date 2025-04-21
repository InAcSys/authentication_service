using AuthenticationService.Application.Services.Abstracts;
using AuthenticationService.Domain.Entities.Concretes;
using AuthenticationService.Infrastructure.Repositories.Interfaces;
using FluentValidation;

namespace AuthenticationService.Application.Services.Concretes
{
    public class SessionService : SessionAbstractService
    {
        public SessionService(IValidator<Session> validator, IRepository<Session, Guid> repository, ILogInRepository logInRepository) : base(validator, repository, logInRepository)
        {
        }
    }
}