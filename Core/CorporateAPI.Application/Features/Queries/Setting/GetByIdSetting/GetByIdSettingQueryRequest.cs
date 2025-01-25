using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Queries.Setting.GetByIdSetting
{
    public class GetByIdSettingQueryRequest:IRequest<GetByIdSettingQueryResponse>
    {
        public int Id { get; set; }
    }
}
