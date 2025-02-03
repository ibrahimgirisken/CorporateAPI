using CorporateAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Seeds
{
    public class LangSeed : IEntityTypeConfiguration<Lang>
    {
        public void Configure(EntityTypeBuilder<Lang> builder)
        {
            builder.HasData(
                new Lang { Id = 1, LangCode = "tr", Title = "Türkçe", Image = "tr.png",CreatedDate= DateTime.Now,UpdatedDate=DateTime.Now },
                new Lang { Id = 2, LangCode = "en", Title = "English", Image = "en.png",CreatedDate=DateTime.Now, UpdatedDate = DateTime.Now },
                new Lang { Id = 3, LangCode = "de", Title = "Deutsch", Image = "de.png",CreatedDate= DateTime.Now, UpdatedDate = DateTime.Now }
                );
        }
    }
}
