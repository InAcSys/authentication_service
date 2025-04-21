using System.Net;
using System.Text;
using System.Text.Json;
using AuthenticationService.Domain.DTOs;
using AuthenticationService.Domain.Entities.Concretes;
using AuthenticationService.Infrastructure.Repositories.Interfaces;
using AuthenticationService.Infrastructure.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace AuthenticationService.Infrastructure.Repositories.Abstracts
{
    public abstract class SessionAbstractRepository : Repository<Session, Guid>, ILogInRepository
    {
        protected SessionAbstractRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<string> LogIn(LogInDTO logIn)
        {
            HttpClient httpClient = new HttpClient();
            string url = "http://user-service:80/api/User/credentials";

            var credential = new CredentialDTO
            {
                Email = logIn.Email,
                Password = logIn.Password
            };

            string json = JsonSerializer.Serialize(credential);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.StatusCode is HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid auth response");
            }

            var authResponse = JsonSerializer.Deserialize<AuthResponseDTO>(responseBody);
            Console.WriteLine($"{authResponse?.UserId} - {authResponse?.RoleId}");

            if (authResponse is null)
            {
                throw new ArgumentException("Resource not found");
            }

            var session = new Session
            {
                Ip = logIn.Ip,
                UserAgent = logIn.UserAgent,
                Device = logIn.Device,
                Browser = logIn.Browser,
                Os = logIn.Os,
                UserId = authResponse.UserId
            };

            await Create(session);

            var jwt = Tokenizer.JWTGenerator(authResponse.UserId, authResponse.RoleId);

            return jwt;
        }
    }
}