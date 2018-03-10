using System.Collections.Generic;
using Akvelon.TestTask.DataAccessLayer.Entities;
using System.Threading.Tasks;

namespace Akvelon.TestTask.Repositories.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProductTransactions
    {
        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="photos">The photos.</param>
        /// <param name="productProductPhotos">The product product photos.</param>
        /// <returns></returns>
        Task DeleteProduct(Product product, List<ProductPhoto> photos, List<ProductProductPhoto> productProductPhotos);

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="productDescription">The product description.</param>
        /// <param name="productPhoto">The product photo.</param>
        /// <returns></returns>
        Task EditProduct(Product product, ProductDescription productDescription, ProductPhoto productPhoto);

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <returns></returns>
        Task<Product> AddProduct(Product product, ProductModel productModel, ProductDescription productDescription,
            ProductPhoto productPhotosList, Culture culture);
    }
}
