using System.Collections.Generic;
using Akvelon.TestTask.DataAccessLayer.Entities;
using System.Threading.Tasks;

namespace Akvelon.TestTask.Repositories.Interfaces
{
    /// <summary>
    /// Product photo repository's interface
    /// </summary>
    public interface IProductPhotoRepository
    {
        /// <summary>
        /// Gets the bicycle photo.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        Task<List<ProductPhoto>> GetProductPhoto(int productId);

        /// <summary>
        /// Gets the bicycles small photos.
        /// </summary>
        /// <param name="productsIds">The products ids.</param>
        /// <returns></returns>
        Task<Dictionary<int,ProductPhoto>> GetProductsSmallPhotos(List<int> productsIds);
    }
}