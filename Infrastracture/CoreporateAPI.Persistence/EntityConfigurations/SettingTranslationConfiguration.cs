using CorporateAPI.Domain.Entities.Setting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreporateAPI.Persistence.EntityConfigurations
{
    public class SettingTranslationConfiguration : IEntityTypeConfiguration<SettingTranslation>
    {
        public void Configure(EntityTypeBuilder<SettingTranslation> builder)
        {
                builder.Property(x => x.Title).HasMaxLength(20);
                builder.Property(x => x.MetaDescription).HasMaxLength(150);
        }
    }
}
