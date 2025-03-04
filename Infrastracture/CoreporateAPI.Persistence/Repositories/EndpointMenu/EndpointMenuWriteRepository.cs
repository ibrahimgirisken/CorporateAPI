using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Application.Repositories.EndpointMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories.EndpointMenu
{
    public class EndpointMenuWriteRepository : WriteRepository<CorporateAPI.Domain.Entities.EndpointMenu.EndpointMenu>, IEndpointMenuWriteRepository
    {
        public EndpointMenuWriteRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
