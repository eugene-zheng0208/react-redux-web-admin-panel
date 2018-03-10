using Akvelon.TestTask.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Akvelon.TestTask.Services.Interfaces
{
    /// <summary>
    /// Bicycles service's interface
    /// </summary>
    public interface IProductsService
    {
        /// <summary>
        /// Gets the full information about bicycle.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        Task<ProductDto> GetFullInformationAboutProduct(int productId);

        /// <summary>
        /// Gets the most popular products.
        /// </summary>
        /// <param name="productsCount">The products count.</param>
        /// <param name="productCategoryName">Name of the product category.</param>
        /// <returns></returns>
        Task<List<PartialProductDto>> GetTheMostPopularProducts(int productsCount, string productCategoryName);

        /// <summary>
        /// Gets products by name.
        /// </summary>
        /// <param name="productName">Name of the product.</param>
        /// <returns></returns>
        Task<List<PartialProductDto>> GetProductsByName(string productName);
    }
}
