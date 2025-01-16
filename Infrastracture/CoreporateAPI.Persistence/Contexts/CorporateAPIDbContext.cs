using CorporateAPI.Domain.Entities;
using CorporateAPI.Domain.Entities.Banner;
using CorporateAPI.Domain.Entities.Common;
using CorporateAPI.Domain.Entities.Home;
using CorporateAPI.Domain.Entities.Identity;
using CorporateAPI.Domain.Entities.Menu;
using CorporateAPI.Domain.Entities.Module;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreporateAPI.Persistence.Contexts
{
    public class CorporateAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public CorporateAPIDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Home> Homes{ get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Lang> Languages { get; set; }
        public DbSet<Banner> Banners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menus");
                entity.HasOne(m => m.Parent)
                .WithMany(m => m.Children)
                .HasForeignKey(m => m.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<MenuTranslation>(entity =>
            {
                entity.ToTable("MenuTranslations");
                entity.HasIndex(mt => mt.Url).IsUnique();
                entity.HasIndex(mt => new { mt.MenuId, mt.Locale }).IsUnique();

                entity.HasOne(mt => mt.Menu)
                .WithMany(mt => mt.MenuTranslations)
                .HasForeignKey(mt => mt.MenuId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PageTranslation>(entity =>
            {
                entity.ToTable("PageTranslations");
                entity.HasIndex(pt => pt.Url).IsUnique();
                entity.HasIndex(pt => new { pt.PageId, pt.Locale }).IsUnique();

                entity.HasOne(pt => pt.Page)
                .WithMany(pt => pt.PageTranslations)
                .HasForeignKey(pt => pt.PageId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ModuleTranslation>(entity =>
            {
                entity.ToTable("ModuleTranslations");
                entity.HasIndex(mt => new { mt.ModuleId, mt.Locale }).IsUnique();
                entity.HasOne(mt => mt.Module)
                .WithMany(mt => mt.ModuleTranslations)
                .HasForeignKey(mt => mt.ModuleId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Home>(entity =>
            {
                entity.HasIndex(h=>h.ContentType).IsUnique();
            });

            modelBuilder.Entity<HomeTranslation>(entity =>
            {
                entity.ToTable("HomeTranslations");
                entity.HasIndex(ht => new { ht.HomeId, ht.Locale }).IsUnique();
                entity.HasOne(bt => bt.Home)
                .WithMany(ht=>ht.HomeTranslations)
                .HasForeignKey(ht=>ht.HomeId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BannerTranslation>(entity =>
            {
                entity.ToTable("BannerTranslations");
                entity.HasIndex(bt => new { bt.BannerId, bt.Locale }).IsUnique();
                entity.HasOne(bt => bt.Banner)
                .WithMany(bt => bt.BannerTranslations)
                .HasForeignKey(bt => bt.BannerId)
                .OnDelete(DeleteBehavior.Restrict);
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
