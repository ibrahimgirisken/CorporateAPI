using Azure.Core;
using CorporateAPI.Application.Abstractions.Services;
using CorporateAPI.Application.Abstractions.Token;
using CorporateAPI.Application.DTOs;
using CorporateAPI.Application.Exceptions;
using CorporateAPI.Application.Features.Commands.AppUser.LoginUser;
using CorporateAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<CorporateAPI.Domain.Entities.Identity.AppUser> _userManager;
        readonly SignInManager<CorporateAPI.Domain.Entities.Identity.AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public Task<Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime)
        {
            throw new NotImplementedException();
        }

        public Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime)
        {
            throw new NotImplementedException();
        }

        public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            CorporateAPI.Domain.Entities.Identity.AppUser? user = await _userManager.FindByNameAsync(usernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(usernameOrEmail);
            if (user == null)
                throw new DirectoryNotFoundException();
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(5);
            }
            throw new AuthenticationErrorException();
        }

        public Task PasswordResetAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
