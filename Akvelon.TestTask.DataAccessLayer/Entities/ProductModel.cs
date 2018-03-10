using System;
using System.Collections.Generic;

namespace Akvelon.TestTask.DataAccessLayer.Entities
{
    /// <summary>
    /// Product's model model
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductModel"/> class.
        /// </summary>
        public ProductModel()
        {
            Product = new HashSet<Product>();
            ProductModelProductDescriptionCulture = new HashSet<ProductModelProductDescriptionCulture>();
        }

        /// <summary>
        /// Gets or sets the product model identifier.
        /// </summary>
        /// <value>
        /// The product model identifier.
        /// </value>
        public int ProductModelId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the catalog description.
        /// </summary>
        /// <value>
        /// The catalog description.
        /// </value>
        public string CatalogDescription { get; set; }

        /// <summary>
        /// Gets or sets the instructions.
        /// </summary>
        /// <value>
        /// The instructions.
        /// </value>
        public string Instructions { get; set; }

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
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public virtual ICollection<Product> Product { get; set; }

        /// <summary>
        /// Gets or sets the product model product description culture.
        /// </summary>
        /// <value>
        /// The product model product description culture.
        /// </value>
        public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCulture { get; set; }
    }
}
