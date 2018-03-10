using Akvelon.TestTask.DataAccessLayer.Entities;
using Akvelon.TestTask.DataTransferObjects;
using Akvelon.TestTask.Repositories.Interfaces;
using Akvelon.TestTask.Services.Interfaces;
using AutoMapper;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Akvelon.TestTask.Services.Services
{
    /// <summary>
    /// Service for managing products (implement CRUD operations)
    /// </summary>
    /// <seealso cref="Akvelon.TestTask.Services.Interfaces.IProductManagingService" />
    public class ProductManagingService : IProductManagingService
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
        /// The culture repository
        /// </summary>
        private readonly ICultureRepository _cultureRepository;

        /// <summary>
        /// The product product photo repository
        /// </summary>
        private readonly IProductProductPhotoRepository _productProductPhotoRepository;

        /// <summary>
        /// The product transactions
        /// </summary>
        private readonly IProductTransactions _productTransactions;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductManagingService" /> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="productDescriptionRepository">The product description repository.</param>
        /// <param name="productPhotoRepository">The product photo repository.</param>
        /// <param name="productTransactions">The product transactions.</param>
        /// <param name="cultureRepository">The culture repository.</param>
        /// <param name="productProductPhotoRepository">The product product photo repository.</param>
        /// <param name="mapper">The mapper.</param>
        public ProductManagingService(IProductRepository productRepository, IProductDescriptionRepository productDescriptionRepository,
            IProductPhotoRepository productPhotoRepository, IProductTransactions productTransactions, ICultureRepository cultureRepository,
            IProductProductPhotoRepository productProductPhotoRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productProductPhotoRepository = productProductPhotoRepository;
            _cultureRepository = cultureRepository;
            _productDescriptionRepository = productDescriptionRepository;
            _productPhotoRepository = productPhotoRepository;
            _productTransactions = productTransactions;
        }

        /// <summary>
        /// Adds the new product.
        /// </summary>
        /// <param name="newProductDto">The new product dto.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<PartialProductDto> AddNewProduct(NewProductDto newProductDto)
        {
            // Creating new product 
            var product = _mapper.Map<NewProductDto, Product>(newProductDto);
            // Stub
            product.ProductNumber = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            product.SafetyStockLevel = 100;
            product.ReorderPoint = 75;
            product.DaysToManufacture = 4;
            product.ProductLine = "R";
            product.Class = "L";
            product.Style = "U";              
            product.WeightUnitMeasureCode = "LB";
            product.SizeUnitMeasureCode = "CM";
            product.SellStartDate = DateTime.Now;

            // Creating new productmodel
            var productModel = new ProductModel()
            {
                Name = newProductDto.ModelName
            };

            // Creating new productPhotos
            var productPhoto = new ProductPhoto()
            {
                LargePhoto = newProductDto.LargePhoto
            };

            // Creating new product description
            var productDescription = new ProductDescription()
            {
                Description = newProductDto.Description
            };

            // Getting english culture object
            var culture = await _cultureRepository.GetCulture("en");

            try
            {
                var addedProduct = await _productTransactions.AddProduct(product, productModel, productDescription, productPhoto, culture);
                var addedProductDto = _mapper.Map<Product, PartialProductDto>(addedProduct); 
                
                return addedProductDto;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteProduct(int productId)
        {
            var product = await _productRepository.GetProductById(productId);
            var productPhoto = await _productPhotoRepository.GetProductPhoto(productId);
            var productProductPhotos = await _productProductPhotoRepository.GetAllProductProductPhotos(productId);

            try
            {
                await _productTransactions.DeleteProduct(product, productPhoto, productProductPhotos);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Edits the product.
        /// </summary>
        /// <param name="newProductDto">The new product dto.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<bool> EditProduct(ProductDto newProductDto)
        {
            var product = await _productRepository.GetProductById(newProductDto.ProductId);
            product.Color = newProductDto.Color;
            product.Size = newProductDto.Size;
            product.ListPrice = newProductDto.ListPrice;
            product.Weight = newProductDto.Weight;
            product.Name = newProductDto.Name;

            // Checking on description changes
            var productModelId = product.ProductModelId.GetValueOrDefault();

            var productDescriptionModel = await _productDescriptionRepository
                .GetProductDescriptionByCulture(productModelId, "English");

            if (newProductDto.Description == productDescriptionModel.Description)
                productDescriptionModel = null;
            else
                productDescriptionModel.Description = newProductDto.Description;

            // Checking on photos changing
            var productPhotoModels = await _productPhotoRepository.GetProductPhoto(newProductDto.ProductId);
            ProductPhoto newPhoto = null;

            if (!productPhotoModels.First().LargePhoto.SequenceEqual(newProductDto.LargePhoto))
            {
                newPhoto = productPhotoModels.First();
                newPhoto.LargePhoto = newProductDto.LargePhoto;
                newPhoto.ThumbNailPhoto = newProductDto.LargePhoto;
            }

            try
            {
                await _productTransactions.EditProduct(product, productDescriptionModel, newPhoto);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

