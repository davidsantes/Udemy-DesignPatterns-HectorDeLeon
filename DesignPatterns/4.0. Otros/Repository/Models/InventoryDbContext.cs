using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DesignPatterns._4._0._Otros.Repository.Models
{
    public partial class InventoryDbContext : DbContext
    {
        public InventoryDbContext()
        {
        }

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<InOut> InOuts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=InventoryDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasMaxLength(50);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<InOut>(entity =>
            {
                entity.HasIndex(e => e.StorageId, "IX_InOuts_StorageId");

                entity.Property(e => e.InOutId).HasMaxLength(50);

                entity.Property(e => e.StorageId).HasMaxLength(50);

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.InOuts)
                    .HasForeignKey(d => d.StorageId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

                entity.Property(e => e.ProductId).HasMaxLength(10);

                entity.Property(e => e.CategoryId).HasMaxLength(50);

                entity.Property(e => e.ProductDescription).HasMaxLength(600);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.HasIndex(e => e.ProductId, "IX_Storages_ProductId");

                entity.HasIndex(e => e.WarehouseId, "IX_Storages_WarehouseId");

                entity.Property(e => e.StorageId).HasMaxLength(50);

                entity.Property(e => e.ProductId).HasMaxLength(10);

                entity.Property(e => e.WarehouseId).HasMaxLength(50);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Storages)
                    .HasForeignKey(d => d.ProductId);

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Storages)
                    .HasForeignKey(d => d.WarehouseId);
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.Property(e => e.WarehouseId).HasMaxLength(50);

                entity.Property(e => e.WarehouseAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.WarehouseName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
