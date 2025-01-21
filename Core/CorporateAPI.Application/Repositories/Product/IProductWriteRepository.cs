using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Repositories.Product
{
    public interface IProductWriteRepository:IWriteRepository<Domain.Entities.Product.Product>
    {
    }
}
