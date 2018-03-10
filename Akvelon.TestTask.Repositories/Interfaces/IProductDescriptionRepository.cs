using Akvelon.TestTask.DataAccessLayer.Entities;
using System.Threading.Tasks;

namespace Akvelon.TestTask.Repositories.Interfaces
{
    /// <summary>
    /// Product description repository's interface
    /// </summary>
    public interface IProductDescriptionRepository
    {
        /// <summary>
        /// Gets the bicycle description by culture.
        /// </summary>
        /// <param name="productModelId">The product model identifier.</param>
        /// <param name="cultureName">Name of the culture.</param>
        /// <returns></returns>
        Task<ProductDescription> GetProductDescriptionByCulture(int productModelId, string cultureName);
    }
}
