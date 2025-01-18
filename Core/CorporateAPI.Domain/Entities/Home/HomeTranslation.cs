using CorporateAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.Home
{
    public class HomeTranslation: BaseTranslation
    {
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? AdditionalData { get; set; }
        public int HomeId { get; set; }
        public Home Home { get; set; }
    }
}
