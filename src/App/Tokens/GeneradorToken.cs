using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Orojas.Api.Models.ViewModels;
using Orojas.App.Tokens.Interfaces;
using Orojas.Core.Entities;
using Orojas.Infraestructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;


namespace Orojas.App.Tokens
{
    /// <summary>
    /// GeneradorToken
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>26/06/2020</date>
    public class GeneradorToken : IGeneradorToken
    {

        private readonly IConfiguration _config;
        public GeneradorToken(IConfiguration config)
        {
            _config = config;
        }
        Token IGeneradorToken.GeneradorToken(LoginViewModel loginViewModel)
        {
            if (loginViewModel == null)
                throw new ArgumentNullException(nameof(loginViewModel));

            Usuario user = new Usuario
            {
                Email = loginViewModel.Email
            };


            SymmetricSecurityKey claveSeguridad = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(
              _config["JwtOptions:ClaveSecreta"]));

            SigningCredentials credenciales = new SigningCredentials(claveSeguridad, SecurityAlgorithms.HmacSha256);
            List<Claim> listClaims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("name", ""),
                new Claim("id", ""),
                new Claim("cualquiercosavalida", "ejemploheaderparavalidar")
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: listClaims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credenciales);

            string json_token = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token
            {
                Token_Auth = json_token,
                Expire_In = TimeSpan.FromHours(2).TotalSeconds,
                NickName = loginViewModel.Email
            };
        }
    }
}