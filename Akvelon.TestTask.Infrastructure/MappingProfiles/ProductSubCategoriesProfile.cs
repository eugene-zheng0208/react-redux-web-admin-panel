using Akvelon.TestTask.DataAccessLayer.Entities;
using Akvelon.TestTask.DataTransferObjects;
using AutoMapper;

namespace Akvelon.TestTask.Infrastructure.MappingProfiles
{
    /// <summary>
    /// Product subCategory model Automapper profile
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ProductSubCategoriesProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCategoriesProfile"/> class.
        /// </summary>
        public ProductSubCategoriesProfile()
        {
            CreateMap<ProductSubcategory, ProductSubCategoryDto>();
        }
    }
}
