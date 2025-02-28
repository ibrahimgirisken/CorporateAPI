using CorporateAPI.Application.CustomAttributes;
using CorporateAPI.Application.DTOs.Configuration;
using CorporateAPI.Application.Services.Configurations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Infrastructure.Services.Configurations
{
    public class ApplicationService : IApplicationService
    {
        public List<Menu> GetAuthorizeDefinitionEndpoints(Type type)
        {
            Assembly assembly = Assembly.GetAssembly(type);
            var controllers = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ControllerBase)));
            List<Menu> menus = new();
            foreach (var controller in controllers)
            {
                var actions = controller.GetMethods().Where(m => m.IsDefined(typeof(AuthorizeDefinitionAttribute)));
                if (actions != null)
                {
                    foreach (var action in actions)
                    {
                        var attributes = action.GetCustomAttributes(true);
                        if (attributes != null)
                        {
                            Menu menu;
                            var authorizeDefinitionAttribute = attributes.FirstOrDefault(a => a.GetType() == typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;
                            if (!menus.Any(m => m.MenuName == authorizeDefinitionAttribute.Menu))
                                menu = new() { MenuName = authorizeDefinitionAttribute.Menu };
                            else
                                menu = menus.FirstOrDefault(m => m.MenuName == authorizeDefinitionAttribute.Menu);

                            CorporateAPI.Application.DTOs.Configuration.Action _action = new()
                            {
                                ActionType = authorizeDefinitionAttribute.ActionType,
                                Definition = authorizeDefinitionAttribute.Definition
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
