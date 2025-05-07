using CorporateAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.Category
{
    public class Category:BaseEntity
    {
        public Category()
        {
            Children=new List<Category?>();
        }
        public string? Image1 { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }=false;
        public Guid? ParentId { get; set; }
        public Category? Parent { get; set; }
        public List<Category?> Children { get; set; }
        public List<Domain.Entities.Product.Product?> Products { get; set; }
        public List<CategoryTranslation> CategoryTranslations { get; set; }
    }
}
