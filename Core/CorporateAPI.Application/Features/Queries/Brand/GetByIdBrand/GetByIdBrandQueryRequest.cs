using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Brand.GetByIdBrand
{
    public class GetByIdBrandQueryRequest:IRequest<GetByIdBrandQueryResponse>
    {
        public int Id { get; set; }
    }
}
