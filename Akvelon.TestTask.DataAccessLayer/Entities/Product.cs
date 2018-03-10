using System;
using System.Collections.Generic;

namespace Akvelon.TestTask.DataAccessLayer.Entities
{
    /// <summary>
    /// Product model
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        public Product()
        {
            ProductProductPhoto = new HashSet<ProductProductPhoto>();
            TransactionHistoryArchive = new HashSet<TransactionHistoryArchive>();
        }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product number.
        /// </summary>
        /// <value>
        /// The product number.
        /// </value>
        public string ProductNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [make flag].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [make flag]; otherwise, <c>false</c>.
        /// </value>
        public bool MakeFlag { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [finished goods flag].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [finished goods flag]; otherwise, <c>false</c>.
        /// </value>
        public bool FinishedGoodsFlag { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the safety stock level.
        /// </summary>
        /// <value>
        /// The safety stock level.
        /// </value>
        public short SafetyStockLevel { get; set; }

        /// <summary>
        /// Gets or sets the reorder point.
        /// </summary>
        /// <value>
        /// The reorder point.
        /// </value>
        public short ReorderPoint { get; set; }

        /// <summary>
        /// Gets or sets the standard cost.
        /// </summary>
        /// <value>
        /// The standard cost.
        /// </value>
        public decimal StandardCost { get; set; }

        /// <summary>
        /// Gets or sets the list price.
        /// </summary>
        /// <value>
        /// The list price.
        /// </value>
        public decimal ListPrice { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the size unit measure code.
        /// </summary>
        /// <value>
        /// The size unit measure code.
        /// </value>
        public string SizeUnitMeasureCode { get; set; }

        /// <summary>
        /// Gets or sets the weight unit measure code.
        /// </summary>
        /// <value>
        /// The weight unit measure code.
        /// </value>
        public string WeightUnitMeasureCode { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        public decimal? Weight { get; set; }

        /// <summary>
        /// Gets or sets the days to manufacture.
        /// </summary>
        /// <value>
        /// The days to manufacture.
        /// </value>
        public int DaysToManufacture { get; set; }

        /// <summary>
        /// Gets or sets the product line.
        /// </summary>
        /// <value>
        /// The product line.
        /// </value>
        public string ProductLine { get; set; }

        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        /// <value>
        /// The class.
        /// </value>
        public string Class { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>
        /// The style.
        /// </value>
        public string Style { get; set; }

        /// <summary>
        /// Gets or sets the product subcategory identifier.
        /// </summary>
        /// <value>
        /// The product subcategory identifier.
        /// </value>
        public int? ProductSubcategoryId { get; set; }

        /// <summary>
        /// Gets or sets the product model identifier.
        /// </summary>
        /// <value>
        /// The product model identifier.
        /// </value>
        public int? ProductModelId { get; set; }

        /// <summary>
        /// Gets or sets the sell start date.
        /// </summary>
        /// <value>
        /// The sell start date.
        /// </value>
        public DateTime SellStartDate { get; set; }

        /// <summary>
        /// Gets or sets the sell end date.
        /// </summary>
        /// <value>
        /// The sell end date.
        /// </value>
        public DateTime? SellEndDate { get; set; }

        /// <summary>
        /// Gets or sets the discontinued date.
        /// </summary>
        /// <value>
        /// The discontinued date.
        /// </value>
        public DateTime? DiscontinuedDate { get; set; }

        /// <summary>
        /// Gets or sets the rowguid.
        /// </summary>
        /// <value>
        /// The rowguid.
        /// </value>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        /// <value>
        /// The modified date.
        /// </value>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the product model.
        /// </summary>
        /// <value>
        /// The product model.
        /// </value>
        public virtual ProductModel ProductModel { get; set; }

        /// <summary>
        /// Gets or sets the product subcategory.
        /// </summary>
        /// <value>
        /// The product subcategory.
        /// </value>
        public virtual ProductSubcategory ProductSubcategory { get; set; }

        /// <summary>
        /// Gets or sets the size unit measure code navigation.
        /// </summary>
        /// <value>
        /// The size unit measure code navigation.
        /// </value>
        public UnitMeasure SizeUnitMeasureCodeNavigation { get; set; }

        /// <summary>
        /// Gets or sets the weight unit measure code navigation.
        /// </summary>
        /// <value>
        /// The weight unit measure code navigation.
        /// </value>
        public UnitMeasure WeightUnitMeasureCodeNavigation { get; set; }

        /// <summary>
        /// Gets or sets the product product photo.
        /// </summary>
        /// <value>
        /// The product product photo.
        /// </value>
        public virtual ICollection<ProductProductPhoto> ProductProductPhoto { get; set; }

        /// <summary>
        /// Gets or sets the transaction history archive.
        /// </summary>
        /// <value>
        /// The transaction history archive.
        /// </value>
        public virtual ICollection<TransactionHistoryArchive> TransactionHistoryArchive { get; set; }
    }
}
