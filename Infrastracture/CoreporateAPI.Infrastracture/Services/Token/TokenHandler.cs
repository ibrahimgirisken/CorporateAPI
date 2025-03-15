using CorporateAPI.Application.Abstractions.Token;
using CorporateAPI.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Infrastracture.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        IConfiguration _configuration { get; set; }

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CorporateAPI.Application.DTOs.Token CreateAccessToken(int minute,AppUser user)
        {
            CorporateAPI.Application.DTOs.Token token = new();
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            token.Expiration = DateTime.Now.AddMinutes(minute);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:issuer"],
                expires: token.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials
                );
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}