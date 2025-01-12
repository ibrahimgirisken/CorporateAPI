using CorporateAPI.Application.DTOs.Page;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.Page.CreatePage
{
    public class CreatePageCommandRequest:IRequest<CreatePageCommandResponse>
    {
        public CreatePageCommandRequest()
        {
            PageTranslations = new HashSet<PageTranslationDTO>();
        }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public int Order { get; set; }
        public string? ModuleIds { get; set; }
        public ICollection<PageTranslationDTO> PageTranslations { get; set; }
    }
}
