using CorporateAPI.Domain.Entities;
using CorporateAPI.Domain.Entities.Banner;
using CorporateAPI.Domain.Entities.Brand;
using CorporateAPI.Domain.Entities.Category;
using CorporateAPI.Domain.Entities.Common;
using CorporateAPI.Domain.Entities.Datasheet;
using CorporateAPI.Domain.Entities.Home;
using CorporateAPI.Domain.Entities.Identity;
using CorporateAPI.Domain.Entities.Menu;
using CorporateAPI.Domain.Entities.Module;
using CorporateAPI.Domain.Entities.Product;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreporateAPI.Persistence.Contexts
{
    public class CorporateAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public CorporateAPIDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Brand> Brands{ get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Lang> Languages { get; set; }
        public DbSet<Banner> Banners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<DatasheetTranslation>(entity =>
            {
                entity.ToTable("DatasheetTranslations");
                entity.HasIndex(dt => dt.Url).IsUnique();

                entity.HasOne(dt=>dt.Datasheet)
                .WithMany(dtt=>dtt.DatasheetTranslations)
                .HasForeignKey(dt=>dt.DatasheetId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(dl=>dl.Language)
                .WithMany(dt=>dt.DatasheetTranslations)
                .HasForeignKey(dl=>dl.Locale)
                .HasPrincipalKey(dt=>dt.LangCode)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(dt => new {dt.DatasheetId,dt.Locale}).IsUnique();
            });

            modelBuilder.Entity<ProductTranslation>(entity =>
            {
                entity.ToTable("ProductTranslations");
                entity.HasIndex(pt => pt.Url).IsUnique();

                entity.HasOne(pt=>pt.Product)
                .WithMany(mt=>mt.ProductTranslations)
                .HasForeignKey(pt=>pt.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pl => pl.Language)
                 .WithMany(l => l.ProductTranslations)
                 .HasForeignKey(pl=>pl.Locale)
                 .HasPrincipalKey(l=>l.LangCode)
                 .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(pt => new { pt.ProductId, pt.Locale }).IsUnique();
            });

            modelBuilder.Entity<CategoryTranslation>(entity =>
            {
                entity.ToTable("CategoryTranslations");
                entity.HasIndex(ct => ct.Url).IsUnique();

                entity.HasOne(ct => ct.Category)
                .WithMany(ct => ct.CategoryTranslations)
                .HasForeignKey(pt => pt.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(l => l.Language)
                 .WithMany(cl => cl.CategoryTranslations)
                 .HasForeignKey(cl => cl.Locale)
                 .HasPrincipalKey(l => l.LangCode)
                 .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(l => new { l.CategoryId, l.Locale }).IsUnique();

            });

            modelBuilder.Entity<MenuTranslation>(entity =>
            {
                entity.ToTable("MenuTranslations");
                entity.HasIndex(mt => mt.Url).IsUnique();

                entity.HasOne(mt => mt.Menu)
                .WithMany(mt => mt.MenuTranslations)
                .HasForeignKey(mt => mt.MenuId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ml=>ml.Language)
                .WithMany(l=>l.MenuTranslations)
                .HasForeignKey(ml=>ml.Locale)
                .HasPrincipalKey(l=>l.LangCode)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(l => new {l.MenuId, l.Locale }).IsUnique();
            });

            modelBuilder.Entity<PageTranslation>(entity =>
            {
                entity.ToTable("PageTranslations");
                entity.HasIndex(pt => pt.Url).IsUnique();

                entity.HasOne(pt => pt.Page)
                .WithMany(pt => pt.PageTranslations)
                .HasForeignKey(pt => pt.PageId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pt=>pt.Language)
                .WithMany(l=>l.PageTranslations)
                .HasForeignKey(pt=>pt.Locale)
                .HasPrincipalKey(l=>l.LangCode)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(l => new { l.PageId, l.Locale }).IsUnique();
            });

            modelBuilder.Entity<ModuleTranslation>(entity =>
            {
                entity.ToTable("ModuleTranslations");
                entity.HasOne(mt => mt.Module)
                .WithMany(mt => mt.ModuleTranslations)
                .HasForeignKey(mt => mt.ModuleId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ml=>ml.Language)
                .WithMany(l=>l.ModuleTranslations)
                .HasForeignKey(ml=>ml.Locale)
                .HasPrincipalKey(l=>l.LangCode)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(l => new { l.ModuleId, l.Locale }).IsUnique();
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

                entity.HasOne(ht=>ht.Language)
                .WithMany(l=>l.HomeTranslations)
                .HasForeignKey(bt => bt.Locale)
                .HasPrincipalKey(l=>l.LangCode)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(l => new { l.HomeId, l.Locale }).IsUnique();
            });

            modelBuilder.Entity<BannerTranslation>(entity =>
            {
                entity.ToTable("BannerTranslations");
                entity.HasOne(bt => bt.Banner)
                .WithMany(bt => bt.BannerTranslations)
                .HasForeignKey(bt => bt.BannerId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(bt => bt.Language)
                .WithMany(l => l.BannerTranslations)
                .HasForeignKey(bt => bt.Locale)     
                .HasPrincipalKey(l => l.LangCode)   
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(bl => new { bl.BannerId, bl.Locale }).IsUnique();
            });

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
