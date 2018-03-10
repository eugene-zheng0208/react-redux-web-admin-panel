using System.Threading.Tasks;
using Akvelon.TestTask.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Akvelon.TestTask.DataAccessLayer.Contexts
{
    /// <summary>
    /// AdventureWorks2014 database context's interface
    /// </summary>
    public interface IAdventureWorks2014Context
    {
        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        /// <value>
        /// The culture.
        /// </value>
        DbSet<Culture> Culture { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        DbSet<Product> Product { get; set; }

        /// <summary>
        /// Gets or sets the product category.
        /// </summary>
        /// <value>
        /// The product category.
        /// </value>
        DbSet<ProductCategory> ProductCategory { get; set; }

        /// <summary>
        /// Gets or sets the product description.
        /// </summary>
        /// <value>
        /// The product description.
        /// </value>
        DbSet<ProductDescription> ProductDescription { get; set; }

        /// <summary>
        /// Gets or sets the product model.
        /// </summary>
        /// <value>
        /// The product model.
        /// </value>
        DbSet<ProductModel> ProductModel { get; set; }

        /// <summary>
        /// Gets or sets the product model product description culture.
        /// </summary>
        /// <value>
        /// The product model product description culture.
        /// </value>
        DbSet<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCulture { get; set; }

        /// <summary>
        /// Gets or sets the product photo.
        /// </summary>
        /// <value>
        /// The product photo.
        /// </value>
        DbSet<ProductPhoto> ProductPhoto { get; set; }

        /// <summary>
        /// Gets or sets the product product photo.
        /// </summary>
        /// <value>
        /// The product product photo.
        /// </value>
        DbSet<ProductProductPhoto> ProductProductPhoto { get; set; }

        /// <summary>
        /// Gets or sets the product subcategory.
        /// </summary>
        /// <value>
        /// The product subcategory.
        /// </value>
        DbSet<ProductSubcategory> ProductSubcategory { get; set; }
        
        /// <summary>
        /// Gets or sets the transaction history archive.
        /// </summary>
        /// <value>
        /// The transaction history archive.
        /// </value>
        DbSet<TransactionHistoryArchive> TransactionHistoryArchive { get; set; }

        /// <summary>
        /// Gets or sets the unit measure.
        /// </summary>
        /// <value>
        /// The unit measure.
        /// </value>
        DbSet<UnitMeasure> UnitMeasure { get; set; }

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}
