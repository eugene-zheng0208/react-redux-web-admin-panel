using System.Threading.Tasks;
using Akvelon.TestTask.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Akvelon.TestTask.Server.Controllers
{
    /// <summary>
    /// Product categories controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        /// <summary>
        /// The product categories service
        /// </summary>
        private readonly IProductCategoriesService _productCategoriesService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriesController"/> class.
        /// </summary>
        /// <param name="productCategoriesService">The product categories service.</param>
        public CategoriesController(IProductCategoriesService productCategoriesService)
        {
            _productCategoriesService = productCategoriesService;
        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Categories/GetAllProductCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categoryDtos = await _productCategoriesService.GetAllCategories();
            if (categoryDtos == null)
                return BadRequest();

            return Ok(categoryDtos);
        }

        /// <summary>
        /// Gets all sub categories.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Categories/GetAllProductSubCategories")]
        public async Task<IActionResult> GetAllProductSubCategories()
        {
            var subCategoryDtos = await _productCategoriesService.GetAllSubCategories();
            if (subCategoryDtos == null)
                return BadRequest();

            return Ok(subCategoryDtos);
        }

        /// <summary>
        /// Gets the category sub categories.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Categories/GetCategorySubCategories")]
        public async Task<IActionResult> GetCategorySubCategories([FromBody] int categoryId)
        {
            var subCategoryDtos = await _productCategoriesService.GetCategorySubCategories(categoryId);
            if (subCategoryDtos == null)
                return BadRequest();

            return Ok(subCategoryDtos);
        }
    }
}
