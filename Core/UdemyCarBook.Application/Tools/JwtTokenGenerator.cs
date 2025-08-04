using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Dtos;
using UdemyCarBook.Application.Feature.MediatR.Results.AppUserResults;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
namespace UdemyCarBook.Application.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(GetCheckAppUserQueryResult getCheckAppUserQueryResult)
        {
            var claims = new List<Claim>();

            if(!string.IsNullOrWhiteSpace(getCheckAppUserQueryResult.Role))
            claims.Add(new Claim(ClaimTypes.Role,getCheckAppUserQueryResult.Role));

            //Username adlı özel bir claim ekleniyor (standart değil, özel bir key).
            claims.Add(new Claim(ClaimTypes.NameIdentifier,getCheckAppUserQueryResult.AppUserId.ToString()));

            if (!string.IsNullOrWhiteSpace(getCheckAppUserQueryResult.Username))
                claims.Add(new Claim("Username",getCheckAppUserQueryResult.Username));

            //token imzlama anahtarı oluşturulur
            //Token’ın şifrelenmesini ve doğrulanmasını sağlayan gizli anahtar burada tanımlanır.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

            //İmza bilgisi(şifreleme) oluşturuluyor
            //Bu imza sayesinde token’ın kim tarafından üretildiği ve değiştirilip değiştirilmediği doğrulanır.
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            JwtSecurityToken token = new JwtSecurityToken(issuer:JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudince, claims:claims,
                notBefore: DateTime.UtcNow, expires:expireDate, signingCredentials:signingCredentials);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            //WriteToken(token) → Token’ı base64 formatında string olarak üretir.
            return new TokenResponseDto(tokenHandler.WriteToken(token), expireDate);
        }
    }
}
