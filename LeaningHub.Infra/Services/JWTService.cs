using LearningHub.Core.data;
using LearningHub.Core.Repository;
using LearningHub.Core.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LeaningHub.Infra.Services
{
    public class JWTService : IJWTService
    {
        private readonly IJWTRepository _JWTrepository;

        public JWTService(IJWTRepository jWTrepository)
        {
            _JWTrepository = jWTrepository;
        }

        public string Auth(UserLogin userLogin)
        {
            var result = _JWTrepository.Auth(userLogin);
            if (result == null)
                return null;
            else
            {
                var secertKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKeyDana@345"));
                var signCredential = new SigningCredentials(secertKey, SecurityAlgorithms.Aes128CbcHmacSha256);
                var claims = new List<Claim>
                {

                    new Claim(ClaimTypes.Name, result.Username),
                    new Claim("RoleId",result.Roleid.ToString())
                };
                var tokenOption = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddHours(24),
                    signingCredentials: signCredential);
                var tokenAsString = new JwtSecurityTokenHandler().WriteToken(tokenOption);
                return tokenAsString;
            }
        }
    }
}
