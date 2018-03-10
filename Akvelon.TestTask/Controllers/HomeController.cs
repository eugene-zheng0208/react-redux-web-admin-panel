using Akvelon.TestTask.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Akvelon.TestTask.Controllers
{
    /// <summary>
    /// Home controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/Home")]
    [EnableCors("MyPolicy")]
    public class HomeController : Controller
    {
        /// <summary>
        /// The products service
        /// </summary>
        private readonly IProductsService _productsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="productsService">The products service.</param>
        public HomeController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        /// <summary>
        /// Gets the bicycles.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Home/GetBicycles")]
        public async Task<IActionResult> GetBicycles()
        {
            var data = await _productsService.GetFiveBicyclesByRaiting(1);

            return Ok(data);
        }
    }
}
