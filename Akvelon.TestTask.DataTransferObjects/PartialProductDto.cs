namespace Akvelon.TestTask.DataTransferObjects
{
    /// <summary>
    /// Bicycle's partial data transfer model
    /// </summary>
    public class PartialProductDto
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the model.
        /// </summary>
        /// <value>
        /// The name of the model.
        /// </value>
        public string ModelName { get; set; }

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
        public decimal? Weight { get; set; }

        /// <summary>
        /// Gets or sets the thumb nail photo.
        /// </summary>
        /// <value>
        /// The thumb nail photo.
        /// </value>
        public byte[] ThumbNailPhoto { get; set; }
    }
}
