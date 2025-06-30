using CoreporateAPI.Persistence.EntityConfigurations;
using CoreporateAPI.Persistence.Seeds;
using CorporateAPI.Domain.Entities;
using CorporateAPI.Domain.Entities.Banner;
using CorporateAPI.Domain.Entities.Brand;
using CorporateAPI.Domain.Entities.Category;
using CorporateAPI.Domain.Entities.Common;
using CorporateAPI.Domain.Entities.Datasheet;
using CorporateAPI.Domain.Entities.Endpoint;
using CorporateAPI.Domain.Entities.EndpointMenu;
using CorporateAPI.Domain.Entities.Home;
using CorporateAPI.Domain.Entities.Identity;
using CorporateAPI.Domain.Entities.Module;
using CorporateAPI.Domain.Entities.Page;
using CorporateAPI.Domain.Entities.Product;
using CorporateAPI.Domain.Entities.Setting;
using CorporateAPI.Domain.Entities.Translation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreporateAPI.Persistence.Contexts
{
    public class CorporateAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public CorporateAPIDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Datasheet> Datasheets { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Lang> Languages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Endpoint> Endpoints { get; set; }
        public DbSet<EndpointMenu> EndpointMenus { get; set; }
        public DbSet<TranslationKey> TranslationKey { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<DatasheetTranslation>(entity =>
            {
                entity.ToTable("DatasheetTranslations");

                entity.HasOne(dt => dt.Datasheet)
                .WithMany(dtt => dtt.DatasheetTranslations)
                .HasForeignKey(dt => dt.DatasheetId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(dl => dl.Lang)
                .WithMany(dt => dt.DatasheetTranslations)
                .HasForeignKey(dl => dl.LangId)
                .HasPrincipalKey(dt => dt.Id)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(dt => new { dt.DatasheetId, dt.LangId }).IsUnique();
            });

            modelBuilder.Entity<SettingTranslation>(entity =>
            {
                entity.ToTable("SettingTranslations");

                entity.HasOne(st => st.Setting)
                .WithMany(st => st.SettingTranslations)
                .HasForeignKey(st => st.SettingId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sl => sl.Lang)
                .WithMany(st => st.SettingTranslations)
                .HasForeignKey(sl => sl.LangId)
                .HasPrincipalKey(st => st.Id)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(st => new { st.SettingId, st.LangId }).IsUnique();
            });


            modelBuilder.Entity<BannerTranslation>(entity =>
            {
                entity.ToTable("BannerTranslations");

                entity.HasOne(bt => bt.Banner)
                .WithMany(bt => bt.BannerTranslations)
                .HasForeignKey(bt => bt.BannerId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(bt => bt.Lang)
                .WithMany(l => l.BannerTranslations)
                .HasForeignKey(bt => bt.LangId)
                .HasPrincipalKey(l => l.Id)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(bl => new { bl.BannerId, bl.LangId }).IsUnique();
            });

            modelBuilder.Entity<ProductTranslation>(entity =>
            {
                entity.ToTable("ProductTranslations");

                entity.HasOne(pt => pt.Product)
                .WithMany(mt => mt.ProductTranslations)
                .HasForeignKey(pt => pt.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pl => pl.Lang)
                 .WithMany(l => l.ProductTranslations)
                 .HasForeignKey(pl => pl.LangId)
                 .HasPrincipalKey(l => l.Id)
                 .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(pt => new { pt.ProductId, pt.LangId }).IsUnique();
            });

            modelBuilder.Entity<CategoryTranslation>(entity =>
            {
                entity.ToTable("CategoryTranslations");

                entity.HasOne(ct => ct.Category)
                .WithMany(ct => ct.CategoryTranslations)
                .HasForeignKey(pt => pt.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(l => l.Lang)
                 .WithMany(cl => cl.CategoryTranslations)
                 .HasForeignKey(cl => cl.LangId)
                 .HasPrincipalKey(l => l.Id)
                 .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(l => new { l.CategoryId, l.LangId }).IsUnique();

            });

            modelBuilder.Entity<PageTranslation>(entity =>
            {
                entity.ToTable("PageTranslations");

                entity.HasOne(pt => pt.Page)
                .WithMany(pt => pt.PageTranslations)
                .HasForeignKey(pt => pt.PageId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pt => pt.Lang)
                .WithMany(l => l.PageTranslations)
                .HasForeignKey(pt => pt.LangId)
                .HasPrincipalKey(l => l.Id)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(l => new { l.PageId, l.LangId }).IsUnique();
            });

            modelBuilder.Entity<TranslationValue>(entity =>
            {
                entity.ToTable("TranslationValues");
                entity.HasOne(tv=>tv.TranslationKey)
                .WithMany(tk => tk.Translations)
                .HasForeignKey(tv=>tv.TranslationKeyId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(tv => tv.Lang)
                .WithMany(l => l.Translations)
                .HasForeignKey(tv => tv.LangId)
                .HasPrincipalKey(l => l.Id)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(tv => new { tv.TranslationKeyId, tv.LangId }).IsUnique();
            });

            modelBuilder.Entity<ModuleTranslation>(entity =>
            {
                entity.ToTable("ModuleTranslations");
                entity.HasOne(mt => mt.Module)
                .WithMany(mt => mt.ModuleTranslations)
                .HasForeignKey(mt => mt.ModuleId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ml => ml.Lang)
                .WithMany(l => l.ModuleTranslations)
                .HasForeignKey(ml => ml.LangId)
                .HasPrincipalKey(l => l.Id)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(l => new { l.ModuleId, l.LangId }).IsUnique();
            });

            modelBuilder.Entity<Home>(entity =>
            {
                entity.HasIndex(h => h.ContentType).IsUnique();
            });

            modelBuilder.Entity<HomeTranslation>(entity =>
            {
                entity.ToTable("HomeTranslations");

                entity.HasOne(bt => bt.Home)
                .WithMany(ht => ht.HomeTranslations)
                .HasForeignKey(ht => ht.HomeId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ht => ht.Lang)
                .WithMany(l => l.HomeTranslations)
                .HasForeignKey(bt => bt.LangId)
                .HasPrincipalKey(l => l.Id)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(l => new { l.HomeId, l.LangId }).IsUnique();
            });
            modelBuilder.Entity<Lang>()
                .HasIndex(l => l.LangCode)
                .IsUnique();

            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    _ => DateTime.Now,
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }

}
