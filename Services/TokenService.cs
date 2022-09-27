using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsersAPI.Model;

namespace UsersAPI.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateToken(IdentityUser<int> user, string role)
        {
            Claim[] userRights = new Claim[]
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:key"))
                );

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: userRights,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddHours(1)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenString);
        }
    }
}
