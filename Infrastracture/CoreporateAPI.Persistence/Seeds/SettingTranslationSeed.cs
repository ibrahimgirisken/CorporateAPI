using CorporateAPI.Domain.Entities.Setting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Seeds
{
    public class SettingTranslationSeed : IEntityTypeConfiguration<SettingTranslation>
    {
        public void Configure(EntityTypeBuilder<SettingTranslation> builder)
        {
            builder.HasData(
                new SettingTranslation
                {
                    Id = 1,
                    SettingId = 1,
                    Locale = "tr",
                    Title = "Title",
                    MetaDescription = "MetaDescription"
                },
                new SettingTranslation
                {
                Id = 2,
                    SettingId = 1,
                    Locale = "en",
                    Title = "Title",
                    MetaDescription = "MetaDescription"
                },
                new SettingTranslation
                {
                Id = 3,
                    SettingId = 1,
                    Locale = "de",
                    Title = "Title",
                    MetaDescription = "MetaDescription"
                });
        }
    }
}
