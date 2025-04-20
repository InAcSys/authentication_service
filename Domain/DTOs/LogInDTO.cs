namespace AuthenticationService.Domain.DTOs
{
    public class LogInDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Ip { get; set; } = "127.0.0.1";
        public string UserAgent { get; set; } = "Unknown";
        public string Device { get; set; } = "Unknown";
        public string Browser { get; set; } = "Unknown";
        public string Os { get; set; } = "Unknown";
    }
}