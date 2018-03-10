using System.Threading.Tasks;
using Akvelon.TestTask.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;

namespace Akvelon.TestTask.DataAccessLayer.Contexts
{
    /// <summary>
    /// AdventureWorks2014 database context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// <seealso cref="Akvelon.TestTask.DataAccessLayer.Contexts.IAdventureWorks2014Context" />
    public class AdventureWorks2014Context : DbContext, IAdventureWorks2014Context
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdventureWorks2014Context"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public AdventureWorks2014Context(DbContextOptions<AdventureWorks2014Context> options)
            : base(options)
        { }

        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        /// <value>
        /// The culture.
        /// </value>
        public DbSet<Culture> Culture { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public DbSet<Product> Product { get; set; }

        /// <summary>
        /// Gets or sets the product category.
        /// </summary>
        /// <value>
        /// The product category.
        /// </value>
        public DbSet<ProductCategory> ProductCategory { get; set; }

        /// <summary>
        /// Gets or sets the product description.
        /// </summary>
        /// <value>
        /// The product description.
        /// </value>
        public DbSet<ProductDescription> ProductDescription { get; set; }

        /// <summary>
        /// Gets or sets the product model.
        /// </summary>
        /// <value>
        /// The product model.
        /// </value>
        public DbSet<ProductModel> ProductModel { get; set; }

        /// <summary>
        /// Gets or sets the product model product description culture.
        /// </summary>
        /// <value>
        /// The product model product description culture.
        /// </value>
        public DbSet<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCulture { get; set; }

        /// <summary>
        /// Gets or sets the product photo.
        /// </summary>
        /// <value>
        /// The product photo.
        /// </value>
        public DbSet<ProductPhoto> ProductPhoto { get; set; }

        /// <summary>
        /// Gets or sets the product product photo.
        /// </summary>
        /// <value>
        /// The product product photo.
        /// </value>
        public DbSet<ProductProductPhoto> ProductProductPhoto { get; set; }

        /// <summary>
        /// Gets or sets the product subcategory.
        /// </summary>
        /// <value>
        /// The product subcategory.
        /// </value>
        public DbSet<ProductSubcategory> ProductSubcategory { get; set; }

        /// <summary>
        /// Gets or sets the transaction history archive.
        /// </summary>
        /// <value>
        /// The transaction history archive.
        /// </value>
        public DbSet<TransactionHistoryArchive> TransactionHistoryArchive { get; set; }

        /// <summary>
        /// Gets or sets the unit measure.
        /// </summary>
        /// <value>
        /// The unit measure.
        /// </value>
        public DbSet<UnitMeasure> UnitMeasure { get; set; }

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task SaveAsync()
        {
            await SaveChangesAsync();
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Culture>(entity =>
            {
                entity.ToTable("Culture", "Production");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_Culture_Name")
                    .IsUnique();

                entity.Property(e => e.CultureId)
                    .HasColumnName("CultureID")
                    .HasColumnType("nchar(6)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name");
            });           

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "Production");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_Product_Name")
                    .IsUnique();

                entity.HasIndex(e => e.ProductNumber)
                    .HasName("AK_Product_ProductNumber")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_Product_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Class).HasColumnType("nchar(2)");

                entity.Property(e => e.Color).HasMaxLength(15);

                entity.Property(e => e.DiscontinuedDate).HasColumnType("datetime");

                entity.Property(e => e.FinishedGoodsFlag)
                    .HasColumnType("Flag")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ListPrice).HasColumnType("money");

                entity.Property(e => e.MakeFlag)
                    .HasColumnType("Flag")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.Property(e => e.ProductLine).HasColumnType("nchar(2)");

                entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");

                entity.Property(e => e.ProductNumber)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.ProductSubcategoryId).HasColumnName("ProductSubcategoryID");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("newid()");

                entity.Property(e => e.SellEndDate).HasColumnType("datetime");

                entity.Property(e => e.SellStartDate).HasColumnType("datetime");

                entity.Property(e => e.Size).HasMaxLength(5);

                entity.Property(e => e.SizeUnitMeasureCode).HasColumnType("nchar(3)");

                entity.Property(e => e.StandardCost).HasColumnType("money");

                entity.Property(e => e.Style).HasColumnType("nchar(2)");

                entity.Property(e => e.Weight).HasColumnType("decimal");

                entity.Property(e => e.WeightUnitMeasureCode).HasColumnType("nchar(3)");

                entity.Property(e => e.SizeUnitMeasureCode).HasColumnType("nchar(3)");

                entity.Property(e => e.WeightUnitMeasureCode).HasColumnType("nchar(3)");

                entity.HasOne(d => d.SizeUnitMeasureCodeNavigation)
                    .WithMany(p => p.ProductSizeUnitMeasureCodeNavigation)
                    .HasForeignKey(d => d.SizeUnitMeasureCode);

                entity.HasOne(d => d.WeightUnitMeasureCodeNavigation)
                    .WithMany(p => p.ProductWeightUnitMeasureCodeNavigation)
                    .HasForeignKey(d => d.WeightUnitMeasureCode);

                entity.HasOne(d => d.ProductModel)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductModelId);

                entity.HasOne(d => d.ProductSubcategory)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductSubcategoryId);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory", "Production");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_ProductCategory_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductCategory_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("newid()");
            });

           

            modelBuilder.Entity<ProductDescription>(entity =>
            {
                entity.ToTable("ProductDescription", "Production");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductDescription_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductDescriptionId).HasColumnName("ProductDescriptionID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("newid()");
            });
         
            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.ToTable("ProductModel", "Production");

                entity.HasIndex(e => e.CatalogDescription)
                    .HasName("PXML_ProductModel_CatalogDescription");

                entity.HasIndex(e => e.Instructions)
                    .HasName("PXML_ProductModel_Instructions");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_ProductModel_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductModel_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");

                entity.Property(e => e.CatalogDescription).HasColumnType("xml");

                entity.Property(e => e.Instructions).HasColumnType("xml");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("newid()");
            });            

            modelBuilder.Entity<ProductModelProductDescriptionCulture>(entity =>
            {
                entity.HasKey(e => new { e.ProductModelId, e.ProductDescriptionId, e.CultureId })
                    .HasName("PK_ProductModelProductDescriptionCulture_ProductModelID_ProductDescriptionID_CultureID");

                entity.ToTable("ProductModelProductDescriptionCulture", "Production");

                entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");

                entity.Property(e => e.ProductDescriptionId).HasColumnName("ProductDescriptionID");

                entity.Property(e => e.CultureId)
                    .HasColumnName("CultureID")
                    .HasColumnType("nchar(6)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.ProductModelProductDescriptionCulture)
                    .HasForeignKey(d => d.CultureId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.ProductDescription)
                    .WithMany(p => p.ProductModelProductDescriptionCulture)
                    .HasForeignKey(d => d.ProductDescriptionId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.ProductModel)
                    .WithMany(p => p.ProductModelProductDescriptionCulture)
                    .HasForeignKey(d => d.ProductModelId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProductPhoto>(entity =>
            {
                entity.ToTable("ProductPhoto", "Production");

                entity.Property(e => e.ProductPhotoId).HasColumnName("ProductPhotoID");

                entity.Property(e => e.LargePhotoFileName).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ThumbnailPhotoFileName).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductProductPhoto>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ProductPhotoId })
                    .HasName("PK_ProductProductPhoto_ProductID_ProductPhotoID");

                entity.ToTable("ProductProductPhoto", "Production");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductPhotoId).HasColumnName("ProductPhotoID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Primary)
                    .HasColumnType("Flag")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductProductPhoto)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.ProductPhoto)
                    .WithMany(p => p.ProductProductPhoto)
                    .HasForeignKey(d => d.ProductPhotoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
          
            modelBuilder.Entity<ProductSubcategory>(entity =>
            {
                entity.ToTable("ProductSubcategory", "Production");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_ProductSubcategory_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductSubcategory_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductSubcategoryId).HasColumnName("ProductSubcategoryID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name");

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("newid()");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.ProductSubcategory)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TransactionHistoryArchive>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.ToTable("TransactionHistoryArchive", "Production");

                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => new { e.ReferenceOrderId, e.ReferenceOrderLineId });

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActualCost).HasColumnType("money");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ReferenceOrderId).HasColumnName("ReferenceOrderID");

                entity.Property(e => e.ReferenceOrderLineId)
                    .HasColumnName("ReferenceOrderLineID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasColumnType("nchar(1)");
            });

            modelBuilder.Entity<UnitMeasure>(entity =>
            {
                entity.HasKey(e => e.UnitMeasureCode);

                entity.ToTable("UnitMeasure", "Production");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_UnitMeasure_Name")
                    .IsUnique();

                entity.Property(e => e.UnitMeasureCode)
                    .HasColumnType("nchar(3)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("Name")
                    .HasMaxLength(4000);
            });
        }
    }
}