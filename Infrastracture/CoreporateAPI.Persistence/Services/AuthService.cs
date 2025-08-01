using CorporateAPI.Application.Abstractions.Services;
using CorporateAPI.Application.Abstractions.Token;
using CorporateAPI.Application.DTOs;
using CorporateAPI.Application.Exceptions;
using CorporateAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;


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
                throw new NotFoundUserException();
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime,user);
                return token;
            }
            throw new NotFoundUserException();
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
