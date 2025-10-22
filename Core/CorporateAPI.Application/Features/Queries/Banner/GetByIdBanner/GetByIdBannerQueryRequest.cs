using MediatR;

namespace CorporateAPI.Application.Features.Queries.Banner.GetByIdBanner
{
    public class GetByIdBannerQueryRequest:IRequest<GetByIdBannerQueryResponse>
    {
        public string Id { get; set; }
        public string? Language { get; set; }
        public bool IncludeAllLanguages { get; set; } = false;
    }
}
