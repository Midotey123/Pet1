using Application.Interfaces;
using Domain.Models;
using Infrastructure.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    internal class JwtProvideService : IJwtProvideService
    {
        private readonly JwtOptions options;
        public JwtProvideService(IOptions<JwtOptions> jwtOptions)
        {
            options = jwtOptions.Value;
        }
        public string GenerateToken(User user)
        {
            var claims = new Claim[] { new("userId", user.Id.ToString())};
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey)),
                SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(options.ExpiresHours));
            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}
