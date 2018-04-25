using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryModule.Models.Masters;
using Microsoft.EntityFrameworkCore;
using InventoryModule.ViewModel;

namespace InventoryModule.Models
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }

        public DbSet<Models.Masters.Products> Products { get; set; }
        public DbSet<Models.Masters.ProductGroup> ProductGroup { get; set; }
        public DbSet<Models.Masters.UnitOfMeasure> UnitOfMeasure { get; set; }
       public DbSet<Models.Masters.ProductUnits> ProductUnits { get; set; }
        public DbSet<Models.Contact> Contacts { get; set; }
        public DbSet<Models.User> Users { get; set; }
       public DbSet<Models.Masters.UnitofMeasureRelations> UnitofMeasureRelations { get; set; }
        public DbSet<Models.Masters.LedgerGroup> LedgerGroups { get; set; }
        public DbSet<Models.Masters.Ledger> Ledgers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().ToTable("Product");
            modelBuilder.Entity<Models.Masters.ProductGroup>().ToTable("ProductGroup");
            modelBuilder.Entity<ProductUnits>().ToTable("ProductUnits");
            modelBuilder.Entity<Models.Masters.UnitOfMeasure>().ToTable("UnitOfMeasure");
            modelBuilder.Entity<LedgerGroup>().ToTable("LedgerGroup");
            modelBuilder.Entity<Ledger>().ToTable("Ledger");

        

        //   modelBuilder.Entity<Models.Masters.ProductUnitRelations>().ToTable("ProductUnitRelation");
            modelBuilder.Entity<Models.Masters.ProductGroup>()
                .HasIndex(x => x.ProductGroupName).IsUnique();
            modelBuilder.Entity<Models.Masters.Products>()
                .HasIndex(x => x.ProductName).IsUnique();
            modelBuilder.Entity<LedgerGroup>()
                .HasIndex(x => x.LedgerGroupName).IsUnique();
            modelBuilder.Entity<Ledger>()
                .HasIndex(x => x.LedgerName).IsUnique();


            modelBuilder.Entity<Models.Masters.ProductUnits>()
                 .HasKey(c => new { c.ProductId, c.UnitId });


         
            //modelBuilder.Entity<Models.Masters.ProductUnits>()
            //    .HasOne(bc => bc.Products)
            //    .WithMany(b => b.ProductUnits)
            //    .HasForeignKey(bc => bc.ProductId);

            //modelBuilder.Entity<Masters.ProductUnits>()
            //    .HasOne(bc => bc.UnitOfMeasure)
            //    .WithMany(c => c.ProductUnits)
            //    .HasForeignKey(bc => bc.UnitId);

        }

//        public DbSet<InventoryModule.ViewModel.ProductwithUnitsViewModel> ProductwithUnitsViewModel { get; set; }
    }
    

}
