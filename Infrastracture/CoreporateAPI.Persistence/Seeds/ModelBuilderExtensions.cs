using CorporateAPI.Domain.Entities;
using CorporateAPI.Domain.Entities.Setting;
using Microsoft.EntityFrameworkCore;

namespace CoreporateAPI.Persistence.Seeds
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lang>().HasData(
     new Lang()
     {
         Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
         LangCode = "tr",
         Title = "Türkçe",
         Image = "tr.png",
         IsDeleted = false,
         CreatedDate = new DateTime(2025, 1, 1),
         UpdatedDate = new DateTime(2025, 1, 1)
     },
     new Lang()
     {
         Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
         LangCode = "en",
         Title = "English",
         Image = "en.png",
         IsDeleted = false,
         CreatedDate = new DateTime(2025, 1, 1),
         UpdatedDate = new DateTime(2025, 1, 1)
     },
     new Lang()
     {
         Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
         LangCode = "de",
         Title = "Deutsch",
         Image = "de.png",
         IsDeleted = false,
         CreatedDate = new DateTime(2025, 1, 1),
         UpdatedDate = new DateTime(2025, 1, 1)
     }
 );

            modelBuilder.Entity<Setting>().HasData(
                new Setting()
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    Telephone = "123456789",
                    Address = "Address",
                    Status = true,
                    IsDeleted = false,
                    CreatedDate = new DateTime(2025, 1, 1),
                    UpdatedDate = new DateTime(2025, 1, 1)
                }
            );

            modelBuilder.Entity<SettingTranslation>().HasData(
                new SettingTranslation()
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    SettingId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    LangId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Title = "Türkçe Title",
                    MetaDescription = "Türkçe Description",
                    IsDeleted = false,
                    CreatedDate = new DateTime(2025, 1, 1),
                    UpdatedDate = new DateTime(2025, 1, 1)
                },
                new SettingTranslation()
                {
                    Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                    SettingId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    LangId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Title = "English Title",
                    MetaDescription = "English Description",
                    IsDeleted = false,
                    CreatedDate = new DateTime(2025, 1, 1),
                    UpdatedDate = new DateTime(2025, 1, 1)
                },
                new SettingTranslation()
                {
                    Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                    SettingId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    LangId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Title = "Deutsch Title",
                    MetaDescription = "Deutsch Description",
                    IsDeleted = false,
                    CreatedDate = new DateTime(2025, 1, 1),
                    UpdatedDate = new DateTime(2025, 1, 1)
                }
            );

        }
    }
}
