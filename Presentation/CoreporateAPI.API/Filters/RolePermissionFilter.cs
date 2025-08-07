using CorporateAPI.Application.Abstractions.Services;
using CorporateAPI.Application.CustomAttributes;
using CorporateAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;

namespace CoreporateAPI.API.Filters
{
    public class RolePermissionFilter : IAsyncActionFilter
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;

        public RolePermissionFilter(IUserService userService, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var username = context.HttpContext.User.Identity?.Name;

            if (!string.IsNullOrEmpty(username))
            {
                var user = await _userManager.FindByNameAsync(username);

                if (user != null && user.Admin)
                {
                    await next();
                    return;
                }

                var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
                var attribute = descriptor?.MethodInfo.GetCustomAttribute<AuthorizeDefinitionAttribute>();
                var httpAttribute = descriptor?.MethodInfo.GetCustomAttribute<HttpMethodAttribute>();

                if (attribute != null)
                {
                    var code = $"{(httpAttribute != null ? httpAttribute.HttpMethods.First() : HttpMethods.Get)}.{attribute.ActionType}.{attribute.Definition.Replace(" ", "")}";

                    var hasRole = await _userService.HasRolePermissionToEndpointAsync(username, code);
                    if (!hasRole)
                    {
                        context.Result = new UnauthorizedResult();
                        return;
                    }
                }
            }

            await next();
        }
    }
}
