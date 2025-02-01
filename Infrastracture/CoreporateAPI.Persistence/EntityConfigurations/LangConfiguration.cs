using CorporateAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreporateAPI.Persistence.EntityConfigurations
{
    public class LangConfiguration : IEntityTypeConfiguration<Lang>
    {
        public void Configure(EntityTypeBuilder<Lang> builder)
        {
            builder.Property(x => x.LangCode).HasMaxLength(3).IsRequired();
            builder.Property(x => x.Image).HasMaxLength(20);
            builder.Property(x => x.Title).HasMaxLength(20);
        }
    }
}
