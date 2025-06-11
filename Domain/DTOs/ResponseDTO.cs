using System.Text.Json.Serialization;

namespace AuthenticationService.Domain.DTOs
{
    public class ResponseDTO
    {
        [JsonPropertyName("data")]
        public AuthResponseDTO? Data { get; set; }
    
        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }
    
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}