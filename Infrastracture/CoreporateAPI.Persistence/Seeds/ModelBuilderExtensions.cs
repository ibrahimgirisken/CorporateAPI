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
                SecurityStamp = "MSV7PQQLRH5YEGZDJDHRZTXA6N2WEGAB",
                ConcurrencyStamp = "4cdedf5f-20f4-4920-ad3e-83a99713be35",
                PasswordHash= "AQAAAAIAAYagAAAAEG4MJ+ifSr2Cgf4m6B/3kqqtSy7sEzXKpwPXebUyLDFeNjfZURlcnrvPOs7o2eStbg==",//0kau1Xlg2X2THhpS
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
            //var passwordHash = new PasswordHasher<AppUser>();
            //string generatedHash = passwordHash.HashPassword(new AppUser(), "0kau1Xlg2X2THhpS");

            modelBuilder.Entity<AppUser>().HasData(adminUser);
            modelBuilder.Entity<Lang>().HasData(
     new Lang()
     {
         Id = Guid.Parse("942e32e5-ed55-4868-8643-0f5087f78d51"),
         LangCode = "tr",
         Title = "Türkçe",
         Image = "tr.png",
         IsDeleted = false,
         CreatedDate = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc),
         UpdatedDate = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc)

     },
     new Lang()
     {
         Id = Guid.Parse("94eba3c1-7851-430e-aeb6-764403053c0c"),
         LangCode = "en",
         Title = "English",
         Image = "en.png",
         IsDeleted = false,
         CreatedDate = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc),
         UpdatedDate = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc)

     },
     new Lang()
     {
         Id = Guid.Parse("140b7478-54e6-4690-bbcb-b621f1702a5d"),
         LangCode = "de",
         Title = "Deutsch",
         Image = "de.png",
         IsDeleted = false,
         CreatedDate = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc),
         UpdatedDate = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc)
     }
 );

            modelBuilder.Entity<Setting>().HasData(
                new Setting()
                {
                    Id = Guid.Parse("64978ef1-7b04-4372-b6fe-18483ee3d753"),
                    Telephone = "123456789",
                    Address = "Address",
                    Status = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc),
                    UpdatedDate = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc)

                }
            );

            modelBuilder.Entity<SettingTranslation>().HasData(
                new SettingTranslation()
                {
                    Id = Guid.Parse("14b628ce-9f8a-40c9-a538-606b3c908bfd"),
                    SettingId = Guid.Parse("64978ef1-7b04-4372-b6fe-18483ee3d753"),
                    LangId = Guid.Parse("942e32e5-ed55-4868-8643-0f5087f78d51"),
                    Title = "Türkçe Title",
                    MetaDescription = "Türkçe Description",
                    IsDeleted = false,
                    CreatedDate = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc),
                    UpdatedDate = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc)

                },
                new SettingTranslation()
                {
                    Id = Guid.Parse("6187c244-aae0-41eb-91ed-ac2f949581a9"),
                    SettingId = Guid.Parse("64978ef1-7b04-4372-b6fe-18483ee3d753"),
                    LangId = Guid.Parse("94eba3c1-7851-430e-aeb6-764403053c0c"),
                    Title = "English Title",
                    MetaDescription = "English Description",
                    IsDeleted = false,
                    CreatedDate = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc),
                    UpdatedDate = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc)

                },
                new SettingTranslation()
                {
                    Id = Guid.Parse("57360389-60af-4832-b99f-deca830dd946"),
                    SettingId = Guid.Parse("64978ef1-7b04-4372-b6fe-18483ee3d753"),
                    LangId = Guid.Parse("140b7478-54e6-4690-bbcb-b621f1702a5d"),
                    Title = "Deutsch Title",
                    MetaDescription = "Deutsch Description",
                    IsDeleted = false,
                    CreatedDate = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc),
                    UpdatedDate = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc)

                }
            );

        }
    }
}
