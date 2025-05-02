using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.Common
{
    public abstract class BaseTranslation:BaseEntity
    {
        public Guid LangId { get; set; }
        public Lang Lang { get; set; }
    }
}
