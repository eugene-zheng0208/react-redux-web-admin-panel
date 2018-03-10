using Akvelon.TestTask.DataAccessLayer.Entities;
using Akvelon.TestTask.DataTransferObjects;
using Akvelon.TestTask.Repositories.Interfaces;
using Akvelon.TestTask.Services.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akvelon.TestTask.Services.Services
{
    /// <summary>
    /// Bicycles service
    /// </summary>
    /// <seealso cref="IProductsService" />
    public class ProductsService : IProductsService
    {
        /// <summary>
        /// The product repository
        /// </summary>
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// The product description repository
        /// </summary>
        private readonly IProductDescriptionRepository _productDescriptionRepository;

        /// <summary>
        /// The product photo repository
        /// </summary>
        private readonly IProductPhotoRepository _productPhotoRepository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsService" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="productDescriptionRepository">The product description repository.</param>
        /// <param name="productPhotoRepository">The product photo repository.</param>
        public ProductsService(IMapper mapper, IProductRepository productRepository,
            IProductDescriptionRepository productDescriptionRepository, IProductPhotoRepository productPhotoRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productDescriptionRepository = productDescriptionRepository;
            _productPhotoRepository = productPhotoRepository;
        }

        /// <summary>
        /// Gets the full information about bicycle.
        /// </summary>
        /// <param name="productId">The bicycle identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<ProductDto> GetFullInformationAboutProduct(int productId)
        {
            var product = await _productRepository.GetFullInformationAboutProduct(productId);
            var productDto = _mapper.Map<Product, ProductDto>(product);

            // Loading product description by product model Id
            var productModelId = product.ProductModelId.GetValueOrDefault();

            var productDescriptionModel = await _productDescriptionRepository
                .GetProductDescriptionByCulture(productModelId, "English");
            productDto.Description = productDescriptionModel.Description;

            // Loading product photos by productId
            var productPhotoModels = await _productPhotoRepository.GetProductPhoto(productId);
            productDto.LargePhoto = productPhotoModels.First().LargePhoto;

            return productDto;
        }

        /// <summary>
        /// Gets the most popular products.
        /// </summary>
        /// <param name="productsCount">The products count.</param>
        /// <param name="productCategoryName">Name of the product category.</param>
        /// <returns></returns>
        public async Task<List<PartialProductDto>> GetTheMostPopularProducts(int productsCount, string productCategoryName)
        {
            var bicycles = await _productRepository.GetTheMostPopularProducts(productsCount, productCategoryName);

            var bicyclesDtos = _mapper.Map<List<Product>, List<PartialProductDto>>(bicycles);
            bicyclesDtos = await AttachPhotosToProducts(bicyclesDtos);

            return bicyclesDtos;
        }

        /// <summary>
        /// Gets products by name.
        /// </summary>
        /// <param name="productName">Name of the product.</param>
        /// <returns></returns>
        public async Task<List<PartialProductDto>> GetProductsByName(string productName)
        {
            productName = productName.Trim(' ');

            var products = await _productRepository.GetProductsByName(productName);
            if (products.Count == 0)
                return new List<PartialProductDto>();

            var productsDtos = _mapper.Map<List<Product>, List<PartialProductDto>>(products);
            productsDtos = await AttachPhotosToProducts(productsDtos);

            return productsDtos;
        }

        /// <summary>
        /// Attaches the photos to products.
        /// </summary>
        /// <param name="productsDtosList">The products dtos list.</param>
        /// <returns></returns>
        private async Task<List<PartialProductDto>> AttachPhotosToProducts(List<PartialProductDto> productsDtosList)
        {
            var productsIds = productsDtosList.Select(b => b.ProductId).ToList();
            var productsPhotos = await _productPhotoRepository.GetProductsSmallPhotos(productsIds);

            foreach (var p in productsDtosList)
            {
                var productId = p.ProductId;

                p.ThumbNailPhoto = productsPhotos[productId].ThumbNailPhoto;
            }

            return productsDtosList;
        }
    }
}
