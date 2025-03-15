using CorporateAPI.Application.Abstractions.Services;
using CorporateAPI.Application.DTOs.User;
using CorporateAPI.Application.Features.Commands.AppUser.CreateUser;
using CorporateAPI.Application.Repositories.Endpoint;
using CorporateAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Services
{
    public class UserService : IUserService
    {
    readonly UserManager<CorporateAPI.Domain.Entities.Identity.AppUser> _userManager;
        readonly IEndpointReadRepository _endpointReadRepository;

        public UserService(UserManager<AppUser> userManager, IEndpointReadRepository endpointReadRepository)
        {
            _userManager = userManager;
            _endpointReadRepository = endpointReadRepository;
        }

        public Task AssignRoleToUserAsync(string userId, string[] roles)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
          IdentityResult result=await _userManager.CreateAsync(new AppUser
            {
              Id=Guid.NewGuid().ToString(),
                Email = model.Email,
                NameSurname = model.NameSurname,
                UserName = model.Username
            }, model.Password);
            CreateUserResponse response = new()
            {
                Succeeded = result.Succeeded,
                Message = result.Succeeded ? "User created successfully" : "User could not be created"
            };
            if (result.Succeeded)
            {
                response.Message = "Kullanıcı başarıyla oluşturuldu.";
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description}\n";
                }
            }
            return response;
        }

        public Task<List<ListUser>> GetAllUsersAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<string[]> GetRolesToUserAsync(string userIdOrName)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
