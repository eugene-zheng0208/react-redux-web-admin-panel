using System;
using System.Collections.Generic;

namespace Akvelon.TestTask.DataAccessLayer.Entities
{
    /// <summary>
    /// Unit measure model
    /// </summary>
    public class UnitMeasure
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitMeasure"/> class.
        /// </summary>
        public UnitMeasure()
        {
            ProductSizeUnitMeasureCodeNavigation = new HashSet<Product>();
            ProductWeightUnitMeasureCodeNavigation = new HashSet<Product>();
        }

        /// <summary>
        /// Gets or sets the unit measure code.
        /// </summary>
        /// <value>
        /// The unit measure code.
        /// </value>
        public string UnitMeasureCode { get; set; }

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
        /// Gets or sets the product size unit measure code navigation.
        /// </summary>
        /// <value>
        /// The product size unit measure code navigation.
        /// </value>
        public ICollection<Product> ProductSizeUnitMeasureCodeNavigation { get; set; }

        /// <summary>
        /// Gets or sets the product weight unit measure code navigation.
        /// </summary>
        /// <value>
        /// The product weight unit measure code navigation.
        /// </value>
        public ICollection<Product> ProductWeightUnitMeasureCodeNavigation { get; set; }
    }
}
