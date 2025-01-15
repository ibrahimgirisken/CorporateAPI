using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Home.GetByIdHome
{
    public class GetByIdHomeQueryRequest:IRequest<GetByIdHomeQueryResponse>
    {
        public int Id { get; set; }
    }
}
