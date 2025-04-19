using AuthenticationService.Domain.Entities.Abstracts;

namespace AuthenticationService.Domain.Entities.Concretes
{
    public class Session : Entity<Guid>
    {
        public string Ip { get; set; } = "127.0.0.1";
        public string UserAgent { get; set; } = "Unknown";
        public string Device { get; set; } = "Unknown";
        public string Browser { get; set; } = "Unknown";
        public string Os { get; set; } = "Unknown";
        public Guid UserId { get; set; }
    }
}