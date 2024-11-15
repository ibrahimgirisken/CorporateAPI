using CorporateAPI.Domain.Entities;
using CorporateAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Contexts
{
    public class CorporateAPIDbContext : DbContext
    {
        public CorporateAPIDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Page> Pages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                .HasOne(m => m.Page)
                .WithOne(m => m.Menu)
                .HasForeignKey<Page>(p => p.MenuId);
            modelBuilder.Entity<Page>()
                .Property(e => e.CreatedDate)
                .HasColumnType("DATETIME")
                .IsRequired();
            modelBuilder.Entity<Page>()
                .Property(e => e.UpdatedDate)
                .HasColumnType("DATETIME")
                .IsRequired();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }

}
