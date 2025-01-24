using CorporateAPI.Application.DTOs.Page;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.Page.CreatePage
{
    public class CreatePageCommandRequest:IRequest<CreatePageCommandResponse>
    {
        public CreatePageCommandRequest()
        {
            PageTranslations = new List<PageTranslationDTO>();
        }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public string? ModuleIds { get; set; }
        public List<PageTranslationDTO> PageTranslations { get; set; }
    }
}
