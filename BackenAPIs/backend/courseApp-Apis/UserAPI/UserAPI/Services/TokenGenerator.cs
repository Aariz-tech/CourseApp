using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System;
using Newtonsoft.Json;

namespace UserAPI.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GenerateToken(int id, string userName,string userEmail)
        {
            var userClaims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,new Guid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName,userName),
                new Claim(JwtRegisteredClaimNames.UniqueName,userEmail),
                new Claim(JwtRegisteredClaimNames.UniqueName,Convert.ToString(id)),


            };
            var userSecretKeyInBytes = Encoding.UTF8.GetBytes("hrisdfehuhfueffuyegyebfbege");
            var userSymmetricKey = new SymmetricSecurityKey(userSecretKeyInBytes);
            var userSigningCredentials = new SigningCredentials(userSymmetricKey, SecurityAlgorithms.HmacSha256);
            var userJwtSecurityToken = new JwtSecurityToken(
                issuer: "UserAppAPI",
                audience: "MVCAppAPI",
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: userSigningCredentials
                );

            var userJwtSecurityTokenHandler = new JwtSecurityTokenHandler().WriteToken(userJwtSecurityToken);
            string userJsonToken = JsonConvert.SerializeObject(new { Token = userJwtSecurityTokenHandler,UserName=userName,Email=userEmail,Id=id });
            return userJsonToken;
        }
    }
}
