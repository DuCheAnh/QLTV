using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WebApiSever.Interface;
using DAL_QuanLy;
using DTO_QuanLy;
namespace WebApiSever
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private DAL_Account Dal_method = new DAL_Account();

        private List<Account_Data> accounts = new List<Account_Data>();

        private readonly string key;

        private void Getdictionary()
        {
            Dal_method.init_client();
            accounts = Dal_method.retrieve_all_user();
        }

        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }

        

        public Model.UserToken Authenticate(string username, string password)
        {
            Getdictionary();

            if (!accounts.Any(u => u.account == username && u.password == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha512)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);
            Model.UserToken Uto = new Model.UserToken();
            Uto.token = tokenHandler.WriteToken(token);


            foreach (Account_Data account in accounts)
            {
                if (account.account == username && account.password == password)
                    Uto.ID = account.UID;
            }

            return Uto;
        }


    }
}
