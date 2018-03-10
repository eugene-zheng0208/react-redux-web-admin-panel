using Akvelon.TestTask.DataAccessLayer.Entities;
using Akvelon.TestTask.DataTransferObjects;
using AutoMapper;

namespace Akvelon.TestTask.Infrastructure.MappingProfiles
{
    /// <summary>
    /// Product model Automapper profile
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ProductsConfig : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsConfig"/> class.
        /// </summary>
        public ProductsConfig()
        {
            CreateMap<Product, PartialProductDto>().
                ForMember(dest => dest.ModelName,
                    opts => opts.MapFrom(src => src.ProductModel.Name));

            CreateMap<Product, ProductDto>().
                ForMember(dest => dest.ModelName,
                    opts => opts.MapFrom(src => src.ProductModel.Name)).
                ForMember(dest => dest.SubcategoryName,
                    opts => opts.MapFrom(src => src.ProductSubcategory.Name));

            CreateMap<NewProductDto, Product>();
        }
    }
}
