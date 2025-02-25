using System;
using System.Collections.Generic;
using Frankenstein2.Models;
using Microsoft.EntityFrameworkCore;

namespace Frankenstein2.Data;

public partial class DmartdbContext : DbContext
{
    public DmartdbContext()
    {
    }

    public DmartdbContext(DbContextOptions<DmartdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlembicVersion> AlembicVersions { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlembicVersion>(entity =>
        {
            entity.HasKey(e => e.VersionNum).HasName("alembic_version_pkc");

            entity.ToTable("alembic_version");

            entity.Property(e => e.VersionNum)
                .HasMaxLength(32)
                .HasColumnName("version_num");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_cart");

            entity.ToTable("cart");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.SalePrice).HasColumnName("sale_price");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Item).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("fk_cart_item_id_items");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_cart_user_id_users");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_items");

            entity.ToTable("items");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.ItemImage)
                .HasColumnType("character varying")
                .HasColumnName("item_image");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Qty).HasColumnName("qty");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_purchases");

            entity.ToTable("purchases");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("character varying")
                .HasColumnName("date");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.SalePrice).HasColumnName("sale_price");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Item).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("fk_purchases_item_id_items");

            entity.HasOne(d => d.User).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_purchases_user_id_users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_users");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Firstname)
                .HasColumnType("character varying")
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasColumnType("character varying")
                .HasColumnName("lastname");
            entity.Property(e => e.PasswordHash)
                .HasColumnType("character varying")
                .HasColumnName("_password_hash");
            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
