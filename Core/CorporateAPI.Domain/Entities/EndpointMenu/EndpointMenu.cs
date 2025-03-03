using CorporateAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.EndpointMenu
{
    public class EndpointMenu:BaseEntity
    {
        public string Name { get; set; }
        public List<Endpoint.Endpoint> Endpoints { get; set; }
    }
}
