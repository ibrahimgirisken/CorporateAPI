using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.Endpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories.Endpoint
{
    public class EndpointReadRepository : ReadRepository<CorporateAPI.Domain.Entities.Endpoint.Endpoint>, IEndpointReadRepository
    {
        public EndpointReadRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
