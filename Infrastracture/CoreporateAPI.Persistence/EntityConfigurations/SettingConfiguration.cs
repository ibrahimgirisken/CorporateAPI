using CorporateAPI.Domain.Entities.Setting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreporateAPI.Persistence.EntityConfigurations
{
    public class SettingConfiguration:IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Telephone).HasMaxLength(25);
            builder.Property(x => x.Address).HasMaxLength(250);
            builder.Property(x => x.BlackLogo).HasMaxLength(150);
            builder.Property(x => x.WhiteLogo).HasMaxLength(150);
            builder.Property(x => x.Email).HasMaxLength(150);
            builder.Property(x => x.Facebook).HasMaxLength(150);
            builder.Property(x => x.Instagram).HasMaxLength(150);
            builder.Property(x => x.LinkedIn).HasMaxLength(150);
            builder.Property(x => x.Youtube).HasMaxLength(150);
            builder.Property(x => x.Twitter).HasMaxLength(150);
            builder.Property(x => x.GoogleMaps).HasMaxLength(400);
            builder.Property(x => x.GooglePlus).HasMaxLength(400);
            builder.Property(x => x.GoogleRecaptcha).HasMaxLength(400);
            builder.Property(x => x.GoogleSiteVerification).HasMaxLength(400);
            builder.Property(x => x.GoogleTagManager).HasMaxLength(400);
            builder.ToTable("Settings");
        }
    }
}
