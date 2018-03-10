using Akvelon.TestTask.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Akvelon.TestTask.DataTransferObjects;

namespace Akvelon.TestTask.Server.Controllers
{
    /// <summary>
    /// Default controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// The products service
        /// </summary>
        private readonly IProductsService _productsService;

        /// <summary>
        /// The product managing service
        /// </summary>
        private readonly IProductManagingService _productManagingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValuesController" /> class.
        /// </summary>
        /// <param name="productsService">The products service.</param>
        /// <param name="productManagingService">The product managing service.</param>
        public ValuesController(IProductsService productsService, IProductManagingService productManagingService)
        {
            _productsService = productsService;
            _productManagingService = productManagingService;
        }

        /// <summary>
        /// Gets the bicycles.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/Value/GetBicycles")]
        public async Task<IActionResult> GetBicycles()
        {
            var data = await _productsService.GetTheMostPopularProducts(5, "Bikes");
            if (data == null)
                return BadRequest();

            return Ok(data);
        }

        /// <summary>
        /// Gets products by name.
        /// </summary>
        /// <param name="productName">Name of the product.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Value/GetProductsByName")]
        public async Task<IActionResult> GetProductsByName([FromBody] string productName)
        {
            var result = await _productsService.GetProductsByName(productName);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        /// <summary>
        /// Gets the product details.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Value/GetProductDetails")]
        public async Task<IActionResult> GetProductDetails([FromBody] int productId)
        {
            var productDetails = await _productsService.GetFullInformationAboutProduct(productId);
            if (productDetails == null)
                return BadRequest();

            return Ok(productDetails);
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Value/DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] int productId)
        {
            var isSuccessfullyDeleted = await _productManagingService.DeleteProduct(productId);
            if (!isSuccessfullyDeleted)
                return BadRequest();

            return Ok();
        }

        /// <summary>
        /// Edits the product.
        /// </summary>
        /// <param name="productDto">The product dto.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Value/EditProduct")]
        public async Task<IActionResult> EditProduct([FromBody] ProductDto productDto)
        {
            var isSuccessfullyEdited = await _productManagingService.EditProduct(productDto);
            if (!isSuccessfullyEdited)
                return BadRequest();

            return Ok();
        }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="newProductDto">The new product dto.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Value/AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] NewProductDto newProductDto)
        {
            var addedProductDto = await _productManagingService.AddNewProduct(newProductDto);
            if (addedProductDto == null)
                return BadRequest();

            return Ok(addedProductDto);
        }
    }
}