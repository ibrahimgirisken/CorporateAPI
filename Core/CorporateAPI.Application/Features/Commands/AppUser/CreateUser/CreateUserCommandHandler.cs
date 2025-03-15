using CorporateAPI.Application.Abstractions.Services;
using CorporateAPI.Application.DTOs.User;
using CorporateAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly Application.Abstractions.Services.IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse response = await _userService.CreateAsync(new()
            {
                Email = request.Email,
                NameSurname = request.NameSurname,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                Username = request.UserName
            });
            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded
            };
        }
    }
}
