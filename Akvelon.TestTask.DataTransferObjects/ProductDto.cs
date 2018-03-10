namespace Akvelon.TestTask.DataTransferObjects
{
    /// <summary>
    /// Bicycle data transfer object
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// The name of the product.
        /// </value>
        public string ModelName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public string Color { get; set; }

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
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        public decimal Weight { get; set; }

        /// <summary>
        /// Gets or sets the name of the subcategory.
        /// </summary>
        /// <value>
        /// The name of the subcategory.
        /// </value>
        public string SubcategoryName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the large photo.
        /// </summary>
        /// <value>
        /// The large photo.
        /// </value>
        public byte[] LargePhoto { get; set; }
    }
}
