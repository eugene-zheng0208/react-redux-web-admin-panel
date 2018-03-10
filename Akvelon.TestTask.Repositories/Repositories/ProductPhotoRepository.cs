using Akvelon.TestTask.DataAccessLayer.Contexts;
using Akvelon.TestTask.DataAccessLayer.Entities;
using Akvelon.TestTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akvelon.TestTask.Repositories.Repositories
{
    /// <summary>
    /// Product photo repository
    /// </summary>
    /// <seealso cref="Akvelon.TestTask.Repositories.Interfaces.IProductPhotoRepository" />
    public class ProductPhotoRepository : IProductPhotoRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly IAdventureWorks2014Context _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductPhotoRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ProductPhotoRepository(IAdventureWorks2014Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the product photo.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public async Task<List<ProductPhoto>> GetProductPhoto(int productId)
        {
            var photo = await _context.ProductProductPhoto.Include(ppp => ppp.ProductPhoto)
                .Where(ppp => ppp.ProductId == productId)
                .Select(ppp => ppp.ProductPhoto)
                .ToListAsync();

            return photo;
        }

        /// <summary>
        /// Gets the product small photos.
        /// </summary>
        /// <param name="productsIds">The products ids.</param>
        /// <returns></returns>
        public async Task<Dictionary<int, ProductPhoto>> GetProductsSmallPhotos(List<int> productsIds)
        {
            var groupedByProductIdPhotos = _context.ProductProductPhoto.Include(ppp => ppp.ProductPhoto)
                .Where(ppp => productsIds.Contains(ppp.ProductId))
                .GroupBy(ppp => ppp.ProductId, ppp => ppp.ProductPhoto);

            var selectedPhotos = await groupedByProductIdPhotos
                .ToDictionaryAsync(kvp => kvp.Key, kvp => kvp.FirstOrDefault());

            return selectedPhotos;
        }
    }
}
