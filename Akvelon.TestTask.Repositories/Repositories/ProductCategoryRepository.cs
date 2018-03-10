using Akvelon.TestTask.DataAccessLayer.Entities;
using Akvelon.TestTask.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Akvelon.TestTask.DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Akvelon.TestTask.Repositories.Repositories
{
    /// <summary>
    /// Product category repository
    /// </summary>
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly IAdventureWorks2014Context _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCategoryRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ProductCategoryRepository(IAdventureWorks2014Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductCategory>> GetAllProductCategories()
        {
            var categories = await _context.ProductCategory.ToListAsync();

            return categories;
        }
    }
}
