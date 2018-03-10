using System.Collections.Generic;
using System.Threading.Tasks;
using Akvelon.TestTask.DataAccessLayer.Entities;

namespace Akvelon.TestTask.Repositories.Interfaces
{
    /// <summary>
    /// Product-prudt photo many to many relationship model repository's interface
    /// </summary>
    public interface IProductProductPhotoRepository
    {
        /// <summary>
        /// Gets all product product photos.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        Task<List<ProductProductPhoto>> GetAllProductProductPhotos(int productId);
    }
}
