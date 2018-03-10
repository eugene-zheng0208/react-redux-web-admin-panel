using Akvelon.TestTask.DataTransferObjects;
using System.Threading.Tasks;

namespace Akvelon.TestTask.Services.Interfaces
{
    /// <summary>
    /// Product managing service's interface
    /// </summary>
    public interface IProductManagingService
    {
        /// <summary>
        /// Adds the new product.
        /// </summary>
        /// <param name="newProductDto">The new product dto.</param>
        /// <returns></returns>
        Task<PartialProductDto> AddNewProduct(NewProductDto newProductDto);

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        Task<bool> DeleteProduct(int productId);

        /// <summary>
        /// Edits the product.
        /// </summary>
        /// <param name="newProductDto">The new product dto.</param>
        /// <returns></returns>
        Task<bool> EditProduct(ProductDto newProductDto);
    }
}
