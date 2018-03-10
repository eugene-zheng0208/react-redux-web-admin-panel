using Akvelon.TestTask.DataAccessLayer.Contexts;
using Akvelon.TestTask.DataAccessLayer.Entities;
using Akvelon.TestTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Akvelon.TestTask.Repositories.Repositories
{
    /// <summary>
    /// Product description repository
    /// </summary>
    /// <seealso cref="Akvelon.TestTask.Repositories.Interfaces.IProductDescriptionRepository" />
    public class ProductDescriptionRepository : IProductDescriptionRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly IAdventureWorks2014Context _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDescriptionRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ProductDescriptionRepository(IAdventureWorks2014Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the bicycle description by culture.
        /// </summary>
        /// <param name="productModelId">The product model identifier.</param>
        /// <param name="cultureName">Name of the culture.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<ProductDescription> GetProductDescriptionByCulture(int productModelId, string cultureName)
        {
            var cultureId = await _context.Culture
                .Where(c => c.Name == cultureName)
                .Select(c => c.CultureId)
                .FirstOrDefaultAsync();

            var description = await _context.ProductModelProductDescriptionCulture
                .Include(ppdc => ppdc.ProductDescription)
                .Where(ppd => ppd.CultureId == cultureId && ppd.ProductModelId == productModelId)
                .Select(ppd => ppd.ProductDescription)
                .FirstOrDefaultAsync();

            return description;
        }
    }
}
