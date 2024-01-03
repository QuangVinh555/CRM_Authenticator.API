﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entites;

public partial class CRMContext : DbContext
{
    public CRMContext(DbContextOptions<CRMContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ProductModel> ProductModels { get; set; }

    public virtual DbSet<StoreModel> StoreModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductModel>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("ProductModel", "tSale");

            entity.Property(e => e.ProductId).ValueGeneratedNever();
            entity.Property(e => e.CommerrcialCode).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.CylinderCapacity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ErpproductCode)
                .HasMaxLength(50)
                .HasColumnName("ERPProductCode");
            entity.Property(e => e.GuaranteePeriod).HasMaxLength(50);
            entity.Property(e => e.ImageUrl).HasMaxLength(100);
            entity.Property(e => e.IsHot).HasColumnName("isHot");
            entity.Property(e => e.IsInventory).HasColumnName("isInventory");
            entity.Property(e => e.LastEditTime).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProcessingValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductCode).HasMaxLength(50);
            entity.Property(e => e.ProductGroups).HasMaxLength(500);
            entity.Property(e => e.ProductName).HasMaxLength(4000);
            entity.Property(e => e.SafeStock).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SampleValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ShortName).HasMaxLength(100);
            entity.Property(e => e.Unit).HasMaxLength(20);
            entity.Property(e => e.WarrantyConditionCode).HasMaxLength(50);
        });

        modelBuilder.Entity<StoreModel>(entity =>
        {
            entity.HasKey(e => e.StoreId);

            entity.ToTable("StoreModel", "tMasterData");

            entity.HasIndex(e => e.CompanyId, "IX_StoreModel_CompanyID");

            entity.Property(e => e.StoreId).ValueGeneratedNever();
            entity.Property(e => e.Area).HasMaxLength(50);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.DefaultCustomerSource).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(500);
            entity.Property(e => e.Fax).HasMaxLength(100);
            entity.Property(e => e.ImageUrl).HasMaxLength(1000);
            entity.Property(e => e.InvoiceStoreName).HasMaxLength(200);
            entity.Property(e => e.LastEditTime).HasColumnType("datetime");
            entity.Property(e => e.LogoUrl).HasMaxLength(1000);
            entity.Property(e => e.MLat)
                .HasMaxLength(50)
                .HasColumnName("mLat");
            entity.Property(e => e.MLong)
                .HasMaxLength(50)
                .HasColumnName("mLong");
            entity.Property(e => e.SaleOrgCode).HasMaxLength(50);
            entity.Property(e => e.SmstemplateCode)
                .HasMaxLength(50)
                .HasColumnName("SMSTemplateCode");
            entity.Property(e => e.StoreAddress).HasMaxLength(500);
            entity.Property(e => e.StoreName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.TelProduct).HasMaxLength(100);
            entity.Property(e => e.TelService).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}