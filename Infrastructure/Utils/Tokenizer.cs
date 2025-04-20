using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationService.Infrastructure.Utils
{
    public static class Tokenizer
    {
        private readonly static string _secretKey = Environment.GetEnvironmentVariable("SECRET_KEY_JWT") ?? "";
        public static string JWTGenerator(Guid userId, int roleId)
        {
            if (string.IsNullOrEmpty(_secretKey))
            {
                throw new ArgumentException("Invalid key configuration");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("UserId", userId.ToString()),
                new Claim("RoleId", roleId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "Sapiens360",
                audience: "SapiensUsers",
                claims,
                expires: DateTime.UtcNow.AddMonths(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}