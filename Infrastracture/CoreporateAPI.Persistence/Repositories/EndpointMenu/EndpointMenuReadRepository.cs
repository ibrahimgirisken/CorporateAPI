using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.EndpointMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories.EndpointMenu
{
    public class EndpointMenuReadRepository : ReadRepository<CorporateAPI.Domain.Entities.EndpointMenu.EndpointMenu>, IEndpointMenuReadRepository
    {
        public EndpointMenuReadRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
