using CorporateAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.Product
{
    public class Product:BaseEntity
    {
        public Product()
        {
            ProductTranslations = new List<ProductTranslation>();
        }
        public string? Code { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Image4 { get; set; }
        public string? Image5 { get; set; }
        public int? Order { get; set; }
        public bool Status { get; set; }=false;
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public Domain.Entities.Category.Category? Category { get; set; }
        public Domain.Entities.Brand.Brand? Brand { get; set; }
        public List<ProductTranslation> ProductTranslations { get; set; }
    }
}
