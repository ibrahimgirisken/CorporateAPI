using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Brand.UpdateBrand
{
    public class UpdateBrandCommandRequest:IRequest<UpdateBrandCommandResponse>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
    }
}
