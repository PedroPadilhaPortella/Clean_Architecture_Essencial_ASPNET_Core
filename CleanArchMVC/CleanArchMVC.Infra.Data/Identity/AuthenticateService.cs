﻿using CleanArchMVC.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticateService(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager
                .PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            var applicationUser = new ApplicationUser { UserName = email, Email = email };
            var result = _userManager.CreateAsync(applicationUser, password);
            if(result.IsCompletedSuccessfully)
            {
                await _signInManager.SignInAsync(applicationUser, isPersistent: false);
            }


            return result.IsCompletedSuccessfully;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
