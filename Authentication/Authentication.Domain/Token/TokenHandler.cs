using Authentication.Domain.Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Authentication.Domain.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly TokenOptions tokenOpt;

        public TokenHandler(IOptions<TokenOptions> _tokenOpt)
        {
            this.tokenOpt = _tokenOpt.Value;
        }


        private IEnumerable<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
           {
              new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
               new Claim(ClaimTypes.Name,$"{user.Name}{user.SurName}"),
                new Claim(JwtRegisteredClaimNames.Email,user.Email.ToString()),
                 new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),

           };

            return claims;
        }


        public AccessToken CreateAccessToken(User user)
        {
            var accessTokenExp = DateTime.Now.AddMinutes(tokenOpt.AccessTokenExpiration);

            var securityKey = SignHandler.GetSecurityKey(tokenOpt.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: tokenOpt.Issuer,
                audience: tokenOpt.Audience,
                expires: accessTokenExp,
                notBefore: DateTime.Now,
                claims: GetClaims(user),
                signingCredentials: signingCredentials

                );

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);


            AccessToken accessToken = new AccessToken();
            accessToken.Token = token;
            accessToken.Expiration = accessTokenExp;
            accessToken.RefreshToken = CreateRefreshToken();


            return accessToken;
        }

        private string CreateRefreshToken()
        {
            var numByte = new Byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(numByte);
                return Convert.ToBase64String(numByte);
            }

        }


    }
}
