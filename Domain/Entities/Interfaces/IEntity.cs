using UserService.Domain.Entities.Interfaces;

namespace AuthenticationService.Domain.Entities.Interfaces
{
    public interface IEntity<TKey> : IDateStamp, ITenant
    {
        public TKey? Id { get; set; }
        public bool IsActive { get; set; }
    }
}