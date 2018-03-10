using System;

namespace Akvelon.TestTask.DataAccessLayer.Entities
{
    /// <summary>
    /// Auxiliary model of the relation product model with localized product description
    /// </summary>
    public class ProductModelProductDescriptionCulture
    {
        /// <summary>
        /// Gets or sets the product model identifier.
        /// </summary>
        /// <value>
        /// The product model identifier.
        /// </value>
        public int ProductModelId { get; set; }

        /// <summary>
        /// Gets or sets the product description identifier.
        /// </summary>
        /// <value>
        /// The product description identifier.
        /// </value>
        public int ProductDescriptionId { get; set; }

        /// <summary>
        /// Gets or sets the culture identifier.
        /// </summary>
        /// <value>
        /// The culture identifier.
        /// </value>
        public string CultureId { get; set; }

        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        /// <value>
        /// The modified date.
        /// </value>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        /// <value>
        /// The culture.
        /// </value>
        public virtual Culture Culture { get; set; }

        /// <summary>
        /// Gets or sets the product description.
        /// </summary>
        /// <value>
        /// The product description.
        /// </value>
        public virtual ProductDescription ProductDescription { get; set; }

        /// <summary>
        /// Gets or sets the product model.
        /// </summary>
        /// <value>
        /// The product model.
        /// </value>
        public virtual ProductModel ProductModel { get; set; }
    }
}
