using CorporateAPI.Domain.Entities;
using CorporateAPI.Domain.Entities.Common;
using CorporateAPI.Domain.Entities.Identity;
using CorporateAPI.Domain.Entities.Relationship;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
        public DbSet<Page> Pages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Page>(entity =>
            {
                entity.ToTable("Page");
                entity.HasOne(m => m.Parent)
                .WithMany(m => m.Children)
                .HasForeignKey(m => m.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PageModule>(entity =>
            entity.HasKey(pm => new { pm.PageId, pm.ModuleId }
            ));

            modelBuilder.Entity<PageModule>(entity =>
            entity.HasOne(pm => pm.Page)
            .WithMany(p=>p.Modules)
            .HasForeignKey(pm=>pm.PageId));

            modelBuilder.Entity<PageModule>(entity =>
            entity.HasOne(pm=>pm.Module)
            .WithMany(m=>m.Pages)
            .HasForeignKey(pm=>pm.ModuleId));

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
