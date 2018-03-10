using System.Threading.Tasks;
using Akvelon.TestTask.DataAccessLayer.Entities;

namespace Akvelon.TestTask.Repositories.Interfaces
{
    /// <summary>
    /// Culture repository interface
    /// </summary>
    public interface ICultureRepository
    {
        /// <summary>
        /// Gets the culture.
        /// </summary>
        /// <param name="cultureId">The culture identifier.</param>
        /// <returns></returns>
        Task<Culture> GetCulture(string cultureId);
    }
}
