using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Domain.Enums.Enums;

namespace Api.Extensions
{
    //Class for general api configuration methods
    public class ConfigExtensions
    {

        //Method to generate token per account
        public string Generate(IConfiguration config, Account account)
        {
            if (account != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("Jwt")["Key"]));
                var credencials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                DateTime expires = DateTime.UtcNow.AddMinutes(Convert.ToUInt32(config.GetSection("Jwt")["Time"]));

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                    new Claim(ClaimTypes.Name, account.Name),
                    new Claim(ClaimTypes.Email, account.Email),
                    new Claim(ClaimTypes.Role, account.RoleType.ToString())
                };

                var token = new JwtSecurityToken(
                    config.GetSection("Jwt")["Issuer"],
                    config.GetSection("Jwt")["Audience"],
                    claims,
                    expires: expires,
                    signingCredentials: credencials
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            return string.Empty;
        }

        //Method to get token by account
        public Account GetToken(string srtoken)
        {
            Account account = new Account();

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            try
            {
                if (handler.ReadToken(srtoken) is JwtSecurityToken token)
                {
                    account.Id = Guid.Parse(token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                    account.Name = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
                    account.Email = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
                    account.RoleType = (RoleType)Enum.Parse(typeof(RoleType), token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value);
                }
            }
            catch { }


            return account;
        }

        //Method to validate request authorization header
        public bool TryRetrieveToken(HttpRequest request, out string token)
        {
            token = null;
            if (string.IsNullOrEmpty(request.Headers["Authorization"].ToString())) return false;
            var bearerToken = request.Headers["Authorization"].ToString();
            token = bearerToken.Replace("Bearer ", "");
            return true;
        }


    }
}
