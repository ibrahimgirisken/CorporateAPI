using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.Common
{
    public abstract class BaseTranslation:BaseEntity
    {
        public string Locale { get; set; }
        public Lang Language { get; set; }
    }
}
