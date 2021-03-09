using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Project1.Data.Entity
{
    public partial class ProjectDBContext : DbContext
    {
        public ProjectDBContext()
        {
        }

        public ProjectDBContext(DbContextOptions<ProjectDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<InventoryLine> InventoryLines { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "Project1");

                entity.HasIndex(e => e.CustomerId, "UQ__Customer__A4AE64D985D2ACDC")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(70);

                entity.Property(e => e.City).HasMaxLength(40);

                entity.Property(e => e.Country).HasMaxLength(40);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.State).HasMaxLength(40);
            });

            modelBuilder.Entity<InventoryLine>(entity =>
            {
                entity.ToTable("InventoryLine", "Project1");

                entity.HasIndex(e => e.InventoryLineId, "UQ__Inventor__BF6B50E05A2355B6")
                    .IsUnique();

                entity.Property(e => e.LineTotal).HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.InventoryLines)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryLine_Location");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InventoryLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryLine_Product");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "Project1");

                entity.HasIndex(e => e.LocationId, "UQ__Location__E7FEA4969102B1F6")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(70);

                entity.Property(e => e.City).HasMaxLength(40);

                entity.Property(e => e.Country).HasMaxLength(40);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(24);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.State).HasMaxLength(40);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order", "Project1");

                entity.HasIndex(e => e.OrderId, "UQ__Order__C3905BCEC78A1BED")
                    .IsUnique();

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.Property(e => e.OrderTotal).HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_CustomerId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_LocationId");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.ToTable("OrderLine", "Project1");

                entity.HasIndex(e => e.OrderLineId, "UQ__OrderLin__29068A11FA473CE7")
                    .IsUnique();

                entity.Property(e => e.LineTotal).HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderLine_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderLine_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "Project1");

                entity.HasIndex(e => e.ProductId, "UQ__Product__B40CC6CC6D2B2871")
                    .IsUnique();

                entity.Property(e => e.BestBy).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UnitPrice).HasColumnType("numeric(10, 2)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "Project1");

                entity.HasIndex(e => e.UserId, "UQ__User__1788CC4DEE47D31B")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__User__536C85E4F6D4FA66")
                    .IsUnique();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
