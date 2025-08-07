using CorporateAPI.Domain.Entities;
using CorporateAPI.Domain.Entities.Identity;
using CorporateAPI.Domain.Entities.Setting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoreporateAPI.Persistence.Seeds
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<AppUser>();

            var adminUser = new AppUser
            {
                Id = "385e28b4-d313-4724-b8c8-1483f15ee8f4",
                NameSurname = "İbrahim GİRİŞKEN",
                Admin = true,
                UserName = "girisken07",
                NormalizedUserName = "GIRISKEN07",
                Email = "girisken07@gmail.com",
                NormalizedEmail = "GIRISKEN07@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAIAAYagAAAAEEQjo+oKKy4mkizENNnOCBDpiMeuDW0QzmWPBn02dK+2+V4vBSjvzPsYe9mbV1C6vg==",
                SecurityStamp = "MSV7PQQLRH5YEGZDJDHRZTXA6N2WEGAB",
                ConcurrencyStamp = "4cdedf5f-20f4-4920-ad3e-83a99713be35",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
            modelBuilder.Entity<AppUser>().HasData(adminUser);
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
