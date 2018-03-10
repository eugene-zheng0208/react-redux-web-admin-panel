using System;
using System.Collections.Generic;

namespace Akvelon.TestTask.DataAccessLayer.Entities
{
    /// <summary>
    /// Product description model
    /// </summary>
    public class ProductDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDescription"/> class.
        /// </summary>
        public ProductDescription()
        {
            ProductModelProductDescriptionCulture = new HashSet<ProductModelProductDescriptionCulture>();
        }

        /// <summary>
        /// Gets or sets the product description identifier.
        /// </summary>
        /// <value>
        /// The product description identifier.
        /// </value>
        public int ProductDescriptionId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

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
        /// Gets or sets the product model product description culture.
        /// </summary>
        /// <value>
        /// The product model product description culture.
        /// </value>
        public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCulture { get; set; }
    }
}
