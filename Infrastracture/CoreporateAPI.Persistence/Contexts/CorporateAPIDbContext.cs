using CorporateAPI.Domain.Entities.MenuEntity;
using CorporateAPI.Domain.Entities.PageEntity;
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
        }
    }

}
