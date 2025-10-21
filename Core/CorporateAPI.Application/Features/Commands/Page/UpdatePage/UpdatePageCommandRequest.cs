using CorporateAPI.Application.DTOs.Page;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Page.UpdatePage
{
    public class UpdatePageCommandRequest:IRequest<UpdatePageCommandResponse>
    {
        public string Id { get; set; }
        public UpdatePageCommandRequest()
        {
            PageTranslations = new List<PageTranslationDTO>();
        }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public string? PageType { get; set; }
        public string? ModuleIds { get; set; }
        public List<PageTranslationDTO> PageTranslations { get; set; }
    }
}
