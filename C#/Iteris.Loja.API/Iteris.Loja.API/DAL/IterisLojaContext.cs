﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Iteris.Loja.API.Domain.Entity;

#nullable disable

namespace Iteris.Loja.API.DAL
{
	public partial class IterisLojaContext : DbContext
	{
		public IterisLojaContext(DbContextOptions<IterisLojaContext> options)
	  : base(options)
		{
		}

		public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<OrderItem> OrderItems { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Supplier> Suppliers { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

			modelBuilder.Entity<Customer>(entity =>
			{
				entity.ToTable("Customer");

				entity.HasIndex(e => new { e.LastName, e.FirstName }, "IndexCustomerName");

				entity.Property(e => e.City).HasMaxLength(40);

				entity.Property(e => e.Country).HasMaxLength(40);

				entity.Property(e => e.FirstName)
					.IsRequired()
					.HasMaxLength(40);

				entity.Property(e => e.LastName)
					.IsRequired()
					.HasMaxLength(40);

				entity.Property(e => e.Phone).HasMaxLength(20);
			});

			modelBuilder.Entity<Order>(entity =>
			{
				entity.ToTable("Order");

				entity.HasIndex(e => e.CustomerId, "IndexOrderCustomerId");

				entity.HasIndex(e => e.OrderDate, "IndexOrderOrderDate");

				entity.Property(e => e.OrderDate)
					.HasColumnType("datetime")
					.HasDefaultValueSql("(getdate())");

				entity.Property(e => e.OrderNumber).HasMaxLength(10);

				entity.Property(e => e.TotalAmount)
					.HasColumnType("decimal(12, 2)")
					.HasDefaultValueSql("((0))");

				entity.HasOne(d => d.Customer)
					.WithMany(p => p.Orders)
					.HasForeignKey(d => d.CustomerId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_ORDER_REFERENCE_CUSTOMER");
			});

			modelBuilder.Entity<OrderItem>(entity =>
			{
				entity.ToTable("OrderItem");

				entity.HasIndex(e => e.OrderId, "IndexOrderItemOrderId");

				entity.HasIndex(e => e.ProductId, "IndexOrderItemProductId");

				entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

				entity.Property(e => e.UnitPrice).HasColumnType("decimal(12, 2)");

				entity.HasOne(d => d.Order)
					.WithMany(p => p.OrderItems)
					.HasForeignKey(d => d.OrderId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_ORDERITE_REFERENCE_ORDER");

				entity.HasOne(d => d.Product)
					.WithMany(p => p.OrderItems)
					.HasForeignKey(d => d.ProductId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_ORDERITE_REFERENCE_PRODUCT");
			});

			modelBuilder.Entity<Product>(entity =>
			{
				entity.ToTable("Product");

				entity.HasIndex(e => e.ProductName, "IndexProductName");

				entity.HasIndex(e => e.SupplierId, "IndexProductSupplierId");

				entity.Property(e => e.Package).HasMaxLength(30);

				entity.Property(e => e.ProductName)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.UnitPrice)
					.HasColumnType("decimal(12, 2)")
					.HasDefaultValueSql("((0))");

				entity.HasOne(d => d.Supplier)
					.WithMany(p => p.Products)
					.HasForeignKey(d => d.SupplierId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_PRODUCT_REFERENCE_SUPPLIER");
			});

			modelBuilder.Entity<Supplier>(entity =>
			{
				entity.ToTable("Supplier");

				entity.HasIndex(e => e.Country, "IndexSupplierCountry");

				entity.HasIndex(e => e.CompanyName, "IndexSupplierName");

				entity.Property(e => e.City).HasMaxLength(40);

				entity.Property(e => e.CompanyName)
					.IsRequired()
					.HasMaxLength(40);

				entity.Property(e => e.ContactName).HasMaxLength(50);

				entity.Property(e => e.ContactTitle).HasMaxLength(40);

				entity.Property(e => e.Country).HasMaxLength(40);

				entity.Property(e => e.Fax).HasMaxLength(30);

				entity.Property(e => e.Phone).HasMaxLength(30);
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
