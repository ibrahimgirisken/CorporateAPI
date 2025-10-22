using MediatR;

namespace CorporateAPI.Application.Features.Queries.Lang.GetByIdLang
{
    public class GetByIdLangRequest:IRequest<GetByIdLangResponse>
    {
        public string Id { get; set; }
    }
}
