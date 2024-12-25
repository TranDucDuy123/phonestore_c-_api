using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WatchAPI.Datas.Models
{
    public partial class WatchStoreContext : DbContext
    {
        public WatchStoreContext()
        {
        }

        public WatchStoreContext(DbContextOptions<WatchStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Import> Imports { get; set; } = null!;
        public virtual DbSet<ImportDetail> ImportDetails { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=MyContext");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Name).HasColumnType("ntext");

                entity.Property(e => e.Password).HasMaxLength(250);

                entity.Property(e => e.UserName).HasMaxLength(250);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Name).HasColumnType("ntext");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.HasIndex(e => e.ProductId, "IX_Cart_ProductId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Name).HasColumnType("ntext");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Address).HasColumnType("ntext");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasColumnType("ntext");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.HasIndex(e => e.ProductId, "IX_Feedback_ProductId");

                entity.Property(e => e.Message).HasColumnType("ntext");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Import>(entity =>
            {
                entity.ToTable("Import");

                entity.HasIndex(e => e.CreateUserId, "IX_Import_CreateUserId");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.Imports)
                    .HasForeignKey(d => d.CreateUserId);
            });

            modelBuilder.Entity<ImportDetail>(entity =>
            {
                entity.ToTable("ImportDetail");

                entity.HasIndex(e => e.ImportId, "IX_ImportDetail_ImportId");

                entity.HasIndex(e => e.ProductId, "IX_ImportDetail_ProductId");

                entity.Property(e => e.PriceIn).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Import)
                    .WithMany(p => p.ImportDetails)
                    .HasForeignKey(d => d.ImportId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ImportDetails)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasIndex(e => e.CustomerId, "IX_Order_CustomerId");

                entity.HasIndex(e => e.UpdateUserId, "IX_Order_UpdateUserId");

                entity.Property(e => e.Address).HasColumnType("ntext");

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name).HasColumnType("ntext");

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Reason).HasColumnType("ntext");

                entity.Property(e => e.ShipFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UpdateUserId);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.HasIndex(e => e.OrderId, "IX_OrderDetail_OrderId");

                entity.HasIndex(e => e.ProductId, "IX_OrderDetail_ProductId");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.BrandId, "IX_Product_BrandId");

                entity.HasIndex(e => e.CategoryId, "IX_Product_CategoryId");

                entity.Property(e => e.Code).HasDefaultValueSql("(N'')");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Effective)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
