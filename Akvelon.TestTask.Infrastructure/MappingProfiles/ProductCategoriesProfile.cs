using Akvelon.TestTask.DataAccessLayer.Entities;
using Akvelon.TestTask.DataTransferObjects;
using AutoMapper;

namespace Akvelon.TestTask.Infrastructure.MappingProfiles
{
    /// <summary>
    /// Product category model Automapper profile
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ProductCategoriesProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCategoriesProfile"/> class.
        /// </summary>
        public ProductCategoriesProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>();
        }
    }
}
