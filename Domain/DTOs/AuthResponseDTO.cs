using System.Text.Json.Serialization;

namespace AuthenticationService.Domain.DTOs
{
    public class AuthResponseDTO
    {
        [JsonPropertyName("userId")]
        public Guid UserId { get; set; }
        [JsonPropertyName("roleId")]
        public int RoleId { get; set; }
        [JsonPropertyName("tenantId")]
        public Guid TenantId { get; set; }
    }
}