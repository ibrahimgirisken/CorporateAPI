using CorporateAPI.Domain.Entities.Common;
using CorporateAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.Endpoint
{
    public class Endpoint: BaseEntity
    {
        public Endpoint()
        {
            Roles = new List<AppRole>();
        }
        public string ActionType { get; set; }
        public string HttpType { get; set; }
        public string Definition { get; set; }
        public string Code { get; set; }
        public EndpointMenu.EndpointMenu EndpointMenu { get; set; }
        public List<AppRole> Roles{ get; set; }
    }
}
