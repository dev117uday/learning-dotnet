using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using AspJwt.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RestSharp;

namespace AspJwt.Data
{
    public class JwtAuthManager : IJwtAuthManager
    {
        private readonly string _key;

        public JwtAuthManager(string jwtKey)
        {
            _key = jwtKey;
        }

        public string Authenticate(string userid, string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userid", userid),
                    new Claim("email", email)
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public User GoogleVerification(IdToken idToken)
        {
            string url = $"https://www.googleapis.com/oauth2/v3/tokeninfo?id_token={idToken.Token}";
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            Dictionary<string, string> newDict =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            if (newDict != null)
            {
                User newUser = new User();
                newUser.Sub = newDict["sub"];
                newUser.Email = newDict["email"];
                return newUser;
            }
            else
            {
                return null;
            }
        }
    }
}