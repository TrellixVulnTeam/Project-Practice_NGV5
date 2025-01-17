﻿using BookStore.API.Helpers.Identity;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.API.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountRepository(UserManager<ApplicationUser> userManger, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManger = userManger;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public async Task<IdentityResult> SingUpAsync(SignUpModel signUpModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = signUpModel.FirstName,
                LastName = signUpModel.FirstName = signUpModel.FirstName,
                Email = signUpModel.Email,
                UserName = signUpModel.Email
            };

            return await _userManger.CreateAsync(user, signUpModel.Password);
        }

        public async Task<string> LogInAsync(SignInModel signInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, false, false);

            if (!result.Succeeded)
            {
                return null;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, signInModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Secret"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
