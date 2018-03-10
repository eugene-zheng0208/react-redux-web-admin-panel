using System;

namespace Akvelon.TestTask.DataAccessLayer.Entities
{
    /// <summary>
    /// Auxiliary model of the relation product with product photos
    /// </summary>
    public class ProductProductPhoto
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product photo identifier.
        /// </summary>
        /// <value>
        /// The product photo identifier.
        /// </value>
        public int ProductPhotoId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ProductProductPhoto"/> is primary.
        /// </summary>
        /// <value>
        ///   <c>true</c> if primary; otherwise, <c>false</c>.
        /// </value>
        public bool Primary { get; set; }

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
        public virtual Product Product { get; set; }

        /// <summary>
        /// Gets or sets the product photo.
        /// </summary>
        /// <value>
        /// The product photo.
        /// </value>
        public virtual ProductPhoto ProductPhoto { get; set; }
    }
}