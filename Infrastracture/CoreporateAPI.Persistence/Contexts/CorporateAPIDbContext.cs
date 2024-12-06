using CorporateAPI.Domain.Entities;
using CorporateAPI.Domain.Entities.Common;
using CorporateAPI.Domain.Entities.Identity;
using CorporateAPI.Domain.Entities.Relationship;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Contexts
{
    public class CorporateAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public CorporateAPIDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Page> Pages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");
                entity.Property(i => i.Id).HasColumnName("Id").UseIdentityColumn();
                entity.Property(i => i.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(100);
                entity.Property(i => i.Url).HasColumnName("Url").HasColumnType("nvarchar").HasMaxLength(120);
                entity.Property(i => i.Priority).HasColumnName("Priority").HasColumnType("int");


                entity.HasOne(m => m.Parent).WithMany(m => m.Children).HasForeignKey(m => m.ParentId).OnDelete(DeleteBehavior.Restrict).HasConstraintName("FK_Menu_ParentMenu");

                modelBuilder.Entity<Menu>().HasOne(m => m.Page).WithMany().HasForeignKey(m => m.PageId).OnDelete(DeleteBehavior.SetNull).HasConstraintName("FK_Menu_Page");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.ToTable("Page");
                entity.Property(i => i.Id).HasColumnName("Id").UseIdentityColumn();
                entity.Property(i => i.Title).HasColumnName("Title").HasColumnType("nvarchar").HasMaxLength(120);
                entity.Property(i => i.Slug).HasColumnName("Slug").HasColumnType("nvarchar").HasMaxLength(120);
            });

            modelBuilder.Entity<PageModule>(entity =>
            {
                entity.ToTable("PageModule");
                entity.HasKey(pm => new { pm.PageId, pm.ModuleId });
                entity.HasOne(pm => pm.Page).WithMany(p => p.PageModules).HasForeignKey(pm => pm.PageId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_PageModule_Page");

                entity.HasOne(pm => pm.Module).WithMany(p => p.PageModules).HasForeignKey(pm => pm.ModuleId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_PageModule_Module");
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
