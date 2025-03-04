using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.Endpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories.Endpoint
{
    public class EndpointWriteRepository : WriteRepository<CorporateAPI.Domain.Entities.Endpoint.Endpoint>, IEndpointWriteRepository
    {
        public EndpointWriteRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
