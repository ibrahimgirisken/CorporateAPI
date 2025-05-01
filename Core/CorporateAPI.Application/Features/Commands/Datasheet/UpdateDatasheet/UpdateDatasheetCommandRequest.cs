using CorporateAPI.Application.DTOs.Datasheet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Datasheet.UpdateDatasheet
{
    public class UpdateDatasheetCommandRequest:IRequest<UpdateDatasheetCommandResponse>
    {
        public string Id { get; set; }
        public UpdateDatasheetCommandRequest()
        {
            DatasheetTranslations = new List<DatasheetTranslationDTO>();
        }
        public string? Code { get; set; }
        public string? Image1 { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public List<DatasheetTranslationDTO> DatasheetTranslations { get; set; }
    }
}
