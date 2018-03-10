using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akvelon.TestTask.DataAccessLayer.Contexts;
using Akvelon.TestTask.DataAccessLayer.Entities;
using Akvelon.TestTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Akvelon.TestTask.Repositories.Repositories
{
    /// <summary>
    /// Product subCategory model repository
    /// </summary>
    /// <seealso cref="Akvelon.TestTask.Repositories.Interfaces.IProductSubCategoryRepository" />
    public class ProductSubCategoryRepository : IProductSubCategoryRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly IAdventureWorks2014Context _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductSubCategoryRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ProductSubCategoryRepository(IAdventureWorks2014Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the name of the product sub category by.
        /// </summary>
        /// <param name="subCategoryName">Name of the sub category.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<ProductSubcategory> GetProductSubCategoryByName(string subCategoryName)
        {
            var productSubCategory = await _context.ProductSubcategory
                .Where(sc => sc.Name == subCategoryName)
                .FirstOrDefaultAsync();

            return productSubCategory;
        }

        /// <summary>
        /// Gets all product sub categories.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductSubcategory>> GetAllProductSubCategories()
        {
            var subCategories = await _context.ProductSubcategory.ToListAsync();

            return subCategories;
        }

        /// <summary>
        /// Gets the category sub categories.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<ProductSubcategory>> GetCategorySubCategories(int categoryId)
        {
            var subCategories = await _context.ProductSubcategory
                .Where(sc => sc.ProductCategoryId == categoryId)
                .ToListAsync();

            return subCategories;
        }
    }
}
