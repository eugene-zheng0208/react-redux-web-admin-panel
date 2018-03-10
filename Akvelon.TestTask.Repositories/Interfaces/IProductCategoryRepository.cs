using System.Collections.Generic;
using System.Threading.Tasks;
using Akvelon.TestTask.DataAccessLayer.Entities;

namespace Akvelon.TestTask.Repositories.Interfaces
{
    /// <summary>
    /// Product cateogry repository's interface
    /// </summary>
    public interface IProductCategoryRepository
    {
        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        Task<List<ProductCategory>> GetAllProductCategories();
    }
}
