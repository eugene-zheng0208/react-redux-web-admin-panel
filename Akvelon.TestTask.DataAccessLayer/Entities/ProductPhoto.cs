using System;
using System.Collections.Generic;

namespace Akvelon.TestTask.DataAccessLayer.Entities
{
    /// <summary>
    /// Product photo model
    /// </summary>
    public class ProductPhoto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductPhoto"/> class.
        /// </summary>
        public ProductPhoto()
        {
            ProductProductPhoto = new HashSet<ProductProductPhoto>();
        }

        /// <summary>
        /// Gets or sets the product photo identifier.
        /// </summary>
        /// <value>
        /// The product photo identifier.
        /// </value>
        public int ProductPhotoId { get; set; }

        /// <summary>
        /// Gets or sets the thumb nail photo.
        /// </summary>
        /// <value>
        /// The thumb nail photo.
        /// </value>
        public byte[] ThumbNailPhoto { get; set; }

        /// <summary>
        /// Gets or sets the name of the thumbnail photo file.
        /// </summary>
        /// <value>
        /// The name of the thumbnail photo file.
        /// </value>
        public string ThumbnailPhotoFileName { get; set; }

        /// <summary>
        /// Gets or sets the large photo.
        /// </summary>
        /// <value>
        /// The large photo.
        /// </value>
        public byte[] LargePhoto { get; set; }

        /// <summary>
        /// Gets or sets the name of the large photo file.
        /// </summary>
        /// <value>
        /// The name of the large photo file.
        /// </value>
        public string LargePhotoFileName { get; set; }

        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        /// <value>
        /// The modified date.
        /// </value>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the product product photo.
        /// </summary>
        /// <value>
        /// The product product photo.
        /// </value>
        public virtual ICollection<ProductProductPhoto> ProductProductPhoto { get; set; }
    }
}
