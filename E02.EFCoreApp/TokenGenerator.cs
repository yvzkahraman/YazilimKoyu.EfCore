using E02.EFCoreApp.Application.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E02.EFCoreApp
{
    public class TokenGenerator
    {
        public TokenResponse GenerateJwt(PersonDto personDto)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.Key));
            SigningCredentials credentials = new SigningCredentials
                (key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role,personDto.RoleDefinition));
            claims.Add(new Claim(ClaimTypes.NameIdentifier,personDto.Id.ToString()));
            claims.Add(new Claim("username", personDto.Username));
            claims.Add(new Claim("name",personDto.Name));
            claims.Add(new Claim("roleInfo", personDto.RoleDefinition));
            claims.Add(new Claim("userId", personDto.Id.ToString()));
            JwtSecurityToken token = new JwtSecurityToken(issuer:JwtInfo.Issuer
                ,audience:JwtInfo.Audience,claims :claims, notBefore:DateTime.UtcNow, expires:DateTime.UtcNow.AddDays(15),signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new TokenResponse( handler.WriteToken(token));
        }
       
    }
}
