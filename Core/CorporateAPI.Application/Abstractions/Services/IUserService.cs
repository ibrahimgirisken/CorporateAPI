using CorporateAPI.Application.DTOs.User;
using CorporateAPI.Application.Features.Commands.AppUser.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser model);
        Task<List<ListUser>> GetAllUsersAsync(int page,int size);
        Task UpdatePasswordAsync(string userId,string resetToken, string newPassword);
        Task AssignRoleToUserAsync(string userId, string[] roles);
        Task<string[]> GetRolesToUserAsync(string userIdOrName);
    }
}
