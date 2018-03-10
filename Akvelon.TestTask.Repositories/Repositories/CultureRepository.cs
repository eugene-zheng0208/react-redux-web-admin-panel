using Akvelon.TestTask.DataAccessLayer.Contexts;
using Akvelon.TestTask.DataAccessLayer.Entities;
using Akvelon.TestTask.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Akvelon.TestTask.Repositories.Repositories
{
    /// <summary>
    /// Culture repository
    /// </summary>
    /// <seealso cref="Akvelon.TestTask.Repositories.Interfaces.ICultureRepository" />
    public class CultureRepository : ICultureRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly IAdventureWorks2014Context _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CultureRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CultureRepository(IAdventureWorks2014Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the culture.
        /// </summary>
        /// <param name="cultureId">The culture identifier.</param>
        /// <returns></returns>
        public async Task<Culture> GetCulture(string cultureId)
        {
            var culture = await _context.Culture.FindAsync(cultureId);

            return culture;
        }
    }
}
