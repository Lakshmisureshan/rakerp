﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Models.Domain;
using WebApplication1.Repositories.Interface;
namespace WebApplication1.Repositories.Implementation
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration configuration;
        public TokenRepository(IConfiguration  configuration)
        {
            this.configuration = configuration;
        }
        public string CreateJwttoken(ApplicationUser user, List<string> roles)
        {
            //create clains from roles
            var claims = new List<Claim>
            {
new Claim(ClaimTypes.Email, user.Email)

            };
            claims.AddRange(roles.Select(role=>new Claim(ClaimTypes.Role, role)));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials =new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: configuration["Jwt:Issuer"], audience:configuration["Jwt:Audience"], claims:claims, expires:DateTime.Now.AddMinutes(15), signingCredentials:credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
