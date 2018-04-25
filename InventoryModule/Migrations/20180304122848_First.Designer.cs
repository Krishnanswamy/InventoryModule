﻿// <auto-generated />
using InventoryModule.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace InventoryModule.Migrations
{
    [DbContext(typeof(InventoryContext))]
    [Migration("20180304122848_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InventoryModule.Models.Masters.ProductGroup", b =>
                {
                    b.Property<int>("ProductGroupID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ProductGroupName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ProductGroupID");

                    b.HasIndex("ProductGroupName")
                        .IsUnique();

                    b.ToTable("ProductGroup");
                });

            modelBuilder.Entity("InventoryModule.Models.Masters.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<int>("ProductGroupId");

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.HasKey("ProductId");

                    b.HasIndex("ProductGroupId");

                    b.HasIndex("ProductName")
                        .IsUnique();

                    b.ToTable("Product");
                });

            modelBuilder.Entity("InventoryModule.Models.Masters.Products", b =>
                {
                    b.HasOne("InventoryModule.Models.Masters.ProductGroup", "ProductGroup")
                        .WithMany("Product")
                        .HasForeignKey("ProductGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
