using System.Collections.Generic;
using System.Threading.Tasks;
using Akvelon.TestTask.DataTransferObjects;

namespace Akvelon.TestTask.Services.Interfaces
{
    /// <summary>
    /// Product categories service's interface
    /// </summary>
    public interface IProductCategoriesService
    {
        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        Task<List<ProductCategoryDto>> GetAllCategories();

        /// <summary>
        /// Gets all sub categories.
        /// </summary>
        /// <returns></returns>
        Task<List<ProductSubCategoryDto>> GetAllSubCategories();

        /// <summary>
        /// Gets all category sub categories.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns></returns>
        Task<List<ProductSubCategoryDto>> GetCategorySubCategories(int categoryId);
    }
}
