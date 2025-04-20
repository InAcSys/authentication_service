using AuthenticationService.Domain.Entities.Concretes;
using FluentValidation;

namespace AuthenticationService.Application.Validators
{
    public class SessionValidator : AbstractValidator<Session>
    {
        public SessionValidator()
        {
            
        }
    }
}