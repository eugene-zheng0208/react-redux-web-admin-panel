using System;
using System.Collections.Generic;

namespace Akvelon.TestTask.DataAccessLayer.Entities
{
    /// <summary>
    /// Culture model
    /// </summary>
    public class Culture
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Culture"/> class.
        /// </summary>
        public Culture()
        {
            ProductModelProductDescriptionCulture = new HashSet<ProductModelProductDescriptionCulture>();
        }

        /// <summary>
        /// Gets or sets the culture identifier.
        /// </summary>
        /// <value>
        /// The culture identifier.
        /// </value>
        public string CultureId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

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
