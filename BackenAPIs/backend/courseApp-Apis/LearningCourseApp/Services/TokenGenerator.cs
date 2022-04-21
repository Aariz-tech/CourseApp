using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LearningCourseApp.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GenerateToken(int id, string courseName,string courseDescription,string price)
        {
            var courseClaims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,new Guid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName,courseName),
                new Claim(JwtRegisteredClaimNames.UniqueName,courseDescription),
                new Claim(JwtRegisteredClaimNames.UniqueName,price),



            };
            var userSecretKeyInBytes = Encoding.UTF8.GetBytes("hrisdfehuhfueffuyegyebfbege");
            var userSymmetricKey = new SymmetricSecurityKey(userSecretKeyInBytes);
            var userSigningCredentials = new SigningCredentials(userSymmetricKey, SecurityAlgorithms.HmacSha256);
            var userJwtSecurityToken = new JwtSecurityToken(
                issuer: "LearningCourseAppAPI",
                audience: "MVCAppAPI",
                claims: courseClaims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: userSigningCredentials
                );

            var userJwtSecurityTokenHandler = new JwtSecurityTokenHandler().WriteToken(userJwtSecurityToken);
            string userJsonToken = JsonConvert.SerializeObject(new { Token = userJwtSecurityTokenHandler,Id=id,CourseName=courseName,CourseDescription=courseDescription,CoursePrice=price });
            return userJsonToken;
        }
    }
}
