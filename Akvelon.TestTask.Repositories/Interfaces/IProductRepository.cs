using Akvelon.TestTask.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Akvelon.TestTask.Repositories.Interfaces
{
    /// <summary>
    /// Product repository's interface
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Gets the full information about bicycle.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        Task<Product> GetFullInformationAboutProduct(int productId);

        /// <summary>
        /// Gets the most popular products.
        /// </summary>
        /// <param name="productsCount">The products count.</param>
        /// <param name="productCategoryName">Name of the product category.</param>
        /// <returns></returns>
        Task<List<Product>> GetTheMostPopularProducts(int productsCount, string productCategoryName);

        /// <summary>
        /// Gets products by name.
        /// </summary>
        /// <param name="productName">Name of the product.</param>
        /// <returns></returns>
        Task<List<Product>> GetProductsByName(string productName);

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        Task DeleteProduct(Product product);

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        Task<Product> GetProductById(int productId);
    }
}
