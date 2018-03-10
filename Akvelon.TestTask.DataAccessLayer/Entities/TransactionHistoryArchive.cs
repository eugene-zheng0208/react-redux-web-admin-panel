using System;

namespace Akvelon.TestTask.DataAccessLayer.Entities
{
    /// <summary>
    /// Transaction model
    /// </summary>
    public class TransactionHistoryArchive
    {
        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        public int TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the reference order identifier.
        /// </summary>
        /// <value>
        /// The reference order identifier.
        /// </value>
        public int ReferenceOrderId { get; set; }

        /// <summary>
        /// Gets or sets the reference order line identifier.
        /// </summary>
        /// <value>
        /// The reference order line identifier.
        /// </value>
        public int ReferenceOrderLineId { get; set; }

        /// <summary>
        /// Gets or sets the transaction date.
        /// </summary>
        /// <value>
        /// The transaction date.
        /// </value>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets the type of the transaction.
        /// </summary>
        /// <value>
        /// The type of the transaction.
        /// </value>
        public string TransactionType { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the actual cost.
        /// </summary>
        /// <value>
        /// The actual cost.
        /// </value>
        public decimal ActualCost { get; set; }

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
    }
}
