using CorporateAPI.Domain.Entities.Datasheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Datasheet
{
    public class ResultDatasheetDTO
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Image1 { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public List<DatasheetTranslationDTO> DatasheetTranslations { get; set; }
    }
}
