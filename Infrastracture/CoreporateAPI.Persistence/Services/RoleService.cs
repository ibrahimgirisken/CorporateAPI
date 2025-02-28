using CorporateAPI.Application.Abstractions.Services;
using CorporateAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Services
{
    public class RoleService : IRoleService
    {
        readonly RoleManager<AppRole> roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public Task CreateRole(string name)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRole(string name)
        {
            throw new NotImplementedException();
        }
    }
}
