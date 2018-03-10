using System;
using System.Collections.Generic;

namespace Akvelon.TestTask.DataAccessLayer.Entities
{
    /// <summary>
    /// Product subCategory model
    /// </summary>
    public class ProductSubcategory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductSubcategory"/> class.
        /// </summary>
        public ProductSubcategory()
        {
            Product = new HashSet<Product>();
        }

        /// <summary>
        /// Gets or sets the product subcategory identifier.
        /// </summary>
        /// <value>
        /// The product subcategory identifier.
        /// </value>
        public int ProductSubcategoryId { get; set; }

        /// <summary>
        /// Gets or sets the product category identifier.
        /// </summary>
        /// <value>
        /// The product category identifier.
        /// </value>
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

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
        /// Gets or sets the product category.
        /// </summary>
        /// <value>
        /// The product category.
        /// </value>
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
