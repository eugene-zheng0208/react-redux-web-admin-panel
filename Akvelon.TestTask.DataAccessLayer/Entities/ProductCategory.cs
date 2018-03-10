using System;
using System.Collections.Generic;

namespace Akvelon.TestTask.DataAccessLayer.Entities
{
    /// <summary>
    /// Product category model
    /// </summary>
    public class ProductCategory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCategory"/> class.
        /// </summary>
        public ProductCategory()
        {
            ProductSubcategory = new HashSet<ProductSubcategory>();
        }

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
        /// Gets or sets the product subcategory.
        /// </summary>
        /// <value>
        /// The product subcategory.
        /// </value>
        public virtual ICollection<ProductSubcategory> ProductSubcategory { get; set; }
    }
}
