namespace AuthenticationService.Domain.DTOs
{
    public class JWTValidateDTO
    {
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
        public Guid TenantId { get; set; }
    }
}