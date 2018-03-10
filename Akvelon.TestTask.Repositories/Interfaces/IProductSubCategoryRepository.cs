using System.Collections.Generic;
using Akvelon.TestTask.DataAccessLayer.Entities;
using System.Threading.Tasks;

namespace Akvelon.TestTask.Repositories.Interfaces
{
    /// <summary>
    /// Product subCategory repository interface
    /// </summary>
    public interface IProductSubCategoryRepository
    {
        /// <summary>
        /// Gets the name of the product sub category by.
        /// </summary>
        /// <param name="subCategoryName">Name of the sub category.</param>
        /// <returns></returns>
        Task<ProductSubcategory> GetProductSubCategoryByName(string subCategoryName);

        /// <summary>
        /// Gets all product sub categories.
        /// </summary>
        /// <returns></returns>
        Task<List<ProductSubcategory>> GetAllProductSubCategories();

        /// <summary>
        /// Gets the category sub categories.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns></returns>
        Task<List<ProductSubcategory>> GetCategorySubCategories(int categoryId);
    }
}
