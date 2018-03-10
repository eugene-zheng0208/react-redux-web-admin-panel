using Akvelon.TestTask.DataAccessLayer.Entities;
using Akvelon.TestTask.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akvelon.TestTask.DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Akvelon.TestTask.Repositories.Repositories
{
    /// <summary>
    /// Product-prudt photo many to many relationship model repository
    /// </summary>
    /// <seealso cref="Akvelon.TestTask.Repositories.Interfaces.IProductProductPhotoRepository" />
    public class ProductProductPhotoRepository : IProductProductPhotoRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly IAdventureWorks2014Context _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductProductPhotoRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ProductProductPhotoRepository(IAdventureWorks2014Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all product product photos.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<ProductProductPhoto>> GetAllProductProductPhotos(int productId)
        {
            var productProductPhotos = await _context.ProductProductPhoto
                .Where(ppp => ppp.ProductId == productId)
                .ToListAsync();

            return productProductPhotos;
        }
    }
}
