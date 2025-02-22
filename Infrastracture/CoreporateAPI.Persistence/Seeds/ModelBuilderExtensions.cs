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
                 new Lang() { Id = 1, LangCode = "tr", Title = "Türkçe", Image = "tr.png", IsDeleted = false, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
                 new Lang() { Id = 2, LangCode = "en", Title = "English", Image = "en.png", IsDeleted = false, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
                 new Lang() { Id = 3, LangCode = "de", Title = "Deutsch", Image = "de.png", IsDeleted = false, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow }
                 );

            modelBuilder.Entity<Setting>().HasData(
                new Setting()
                {
                    Id = 1,
                    Telephone = "123456789",
                    Address = "Address",
                    Status = true,
                    IsDeleted = false,
                    CreatedDate = System.DateTime.Now,
                    UpdatedDate = System.DateTime.Now
                });

            modelBuilder.Entity<SettingTranslation>().HasData(

                new SettingTranslation()
                {
                    Id = 1,
                    SettingId = 1,
                    Locale = "tr",
                    Title = "Türkçe Title",
                    MetaDescription = "Türkçe Description",
                    IsDeleted = false,
                    CreatedDate = System.DateTime.Now,
                    UpdatedDate = System.DateTime.Now
                },
                new SettingTranslation()
                {
                    Id = 2,
                    SettingId = 1,
                    Locale = "en",
                    Title = "English Title",
                    MetaDescription = "English Description",
                    IsDeleted = false,
                    CreatedDate = System.DateTime.Now,
                    UpdatedDate = System.DateTime.Now
                },
                new SettingTranslation()
                {
                    Id = 3,
                    SettingId = 1,
                    Locale = "de",
                    Title = "Deutsch Title",
                    MetaDescription = "Deutsch Description",
                    IsDeleted = false,
                    CreatedDate = System.DateTime.Now,
                    UpdatedDate = System.DateTime.Now
                });
        }
    }
}
