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
        readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            this._roleManager = roleManager;
        }

        public async Task<bool> CreateRole(string name)
        {
         IdentityResult result= await _roleManager.CreateAsync(new() {Id=Guid.NewGuid().ToString(), Name = name });
            return result.Succeeded;
        }

        public async Task<bool> DeleteRole(string id)
        {
            IdentityResult result=await _roleManager.DeleteAsync(new() { Id= id });
            return result.Succeeded;
        }

        public (object,int) GetAllRoles(int page,int size)
        {
            var data= _roleManager.Roles.Skip(page*size).Take(size).ToDictionary(role=>role.Id, role => role.Name);
            return (data, _roleManager.Roles.Count());
        }

        public async Task<(string id, string name)> GetRoleById(string id)
        {
           string role=await _roleManager.GetRoleIdAsync(new() { Id = id });
            return (id, role);
        }

        public async Task<bool> UpdateRole(string id,string name)
        {
            AppRole appRole = await _roleManager.FindByIdAsync(id);
           IdentityResult result=await _roleManager.UpdateAsync(appRole);
            return result.Succeeded;
        }
    }
}
