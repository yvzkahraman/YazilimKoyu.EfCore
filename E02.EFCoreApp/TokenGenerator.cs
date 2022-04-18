using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E02.EFCoreApp
{
    public class TokenGenerator
    {
        public string GenerateJwt()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.Key));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role,"Member"));
            //claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            JwtSecurityToken token = new JwtSecurityToken(issuer:JwtInfo.Issuer
                ,audience:JwtInfo.Audience,claims :claims, notBefore:DateTime.UtcNow, expires:DateTime.UtcNow.AddDays(15),signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
       
    }
}
