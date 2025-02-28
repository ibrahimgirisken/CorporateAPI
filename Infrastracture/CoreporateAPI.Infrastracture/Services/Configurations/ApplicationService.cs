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
        public List<Menu> GetAuthorizeDefinitionEndpoints()
        {
            Assembly assembly= Assembly.GetExecutingAssembly();
            assembly.GetTypes().Where(t=>t.IsAssignableTo(typeof(ControllerBase)));
            return null;
        }
    }
}
