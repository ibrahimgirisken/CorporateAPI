using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
       public DTOs.Token CreateAccessToken(int minute);
    }
}
