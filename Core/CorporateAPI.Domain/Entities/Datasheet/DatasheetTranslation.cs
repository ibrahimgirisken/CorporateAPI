using CorporateAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.Datasheet
{
    public class DatasheetTranslation:BaseTranslation
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? Content { get; set; }
        public string? Path { get; set; }
        public int DatasheetId { get; set; }
        public Datasheet Datasheet { get; set; }
    }
}
