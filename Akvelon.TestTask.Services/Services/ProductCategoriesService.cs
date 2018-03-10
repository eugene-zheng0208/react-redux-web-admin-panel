using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Akvelon.TestTask.DataAccessLayer.Entities;
using Akvelon.TestTask.DataTransferObjects;
using Akvelon.TestTask.Repositories.Interfaces;
using Akvelon.TestTask.Services.Interfaces;
using AutoMapper;

namespace Akvelon.TestTask.Services.Services
{
    /// <summary>
    /// Product categories/subcategories service
    /// </summary>
    /// <seealso cref="Akvelon.TestTask.Services.Interfaces.IProductCategoriesService" />
    public class ProductCategoriesService : IProductCategoriesService
    {
        /// <summary>
        /// The product sub category repository
        /// </summary>
        private readonly IProductSubCategoryRepository _productSubCategoryRepository;

        /// <summary>
        /// The product category repository
        /// </summary>
        private readonly IProductCategoryRepository _productCategoryRepository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCategoriesService"/> class.
        /// </summary>
        /// <param name="productSubCategoryRepository">The product sub category repository.</param>
        /// <param name="productCategoryRepository">The product category repository.</param>
        /// <param name="mapper">The mapper.</param>
        public ProductCategoriesService(IProductSubCategoryRepository productSubCategoryRepository, IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productSubCategoryRepository = productSubCategoryRepository;
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<ProductCategoryDto>> GetAllCategories()
        {
            var categories = await _productCategoryRepository.GetAllProductCategories();
            var categoriesDtos = _mapper.Map<List<ProductCategory>, List<ProductCategoryDto>>(categories);

            return categoriesDtos;
        }

        /// <summary>
        /// Gets all sub categories.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<ProductSubCategoryDto>> GetAllSubCategories()
        {
            var subCategories = await _productSubCategoryRepository.GetAllProductSubCategories();
            var subCategoriesDtos = _mapper.Map<List<ProductSubcategory>, List<ProductSubCategoryDto>>(subCategories);

            return subCategoriesDtos;
        }

        /// <summary>
        /// Gets all category sub categories.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<ProductSubCategoryDto>> GetCategorySubCategories(int categoryId)
        {
            var subCategories = await _productSubCategoryRepository.GetCategorySubCategories(categoryId);
            var subCategoriesDtos = _mapper.Map<List<ProductSubcategory>, List<ProductSubCategoryDto>>(subCategories);

            return subCategoriesDtos;
        }
    }
}
