using MediatR;

namespace CorporateAPI.Application.Features.Queries.Setting.GetByIdSetting
{
    public class GetByIdSettingQueryRequest:IRequest<GetByIdSettingQueryResponse>
    {
        public string Id { get; set; }
    }
}
