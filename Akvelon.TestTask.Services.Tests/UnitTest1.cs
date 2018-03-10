using Akvelon.TestTask.DataAccessLayer.Entities;
using Akvelon.TestTask.DataTransferObjects;
using Akvelon.TestTask.Repositories.Interfaces;
using Akvelon.TestTask.Services.Services;
using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Akvelon.TestTask.Services.Tests
{
    /// <summary>
    /// Product service test class
    /// </summary>
    public class ProductsServiceTests
    {
        /// <summary>
        /// Gets the products by name test.
        /// </summary>
        [Fact]
        public void GetProductsByNameTest()
        {
            // Arrange
            var productRepositoryMock = new Mock<IProductRepository>();
            var searchingName = "TouR";
            var resultAsync = GetTestProductsAsync();
            productRepositoryMock.Setup(repo => repo.GetProductsByName(searchingName))
                .Returns(resultAsync);

            var productPhotoRepositoryMock = new Mock<IProductPhotoRepository>();
            productPhotoRepositoryMock.Setup(repo => repo.GetProductsSmallPhotos(It.IsAny<List<int>>()))
                .Returns(GetProductsPhotosAsync());

            var productDescriptionRepository = new Mock<IProductDescriptionRepository>().Object;

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<List<Product>, List<PartialProductDto>>(resultAsync.Result))
                .Returns(MapProductToPartialProductDto());

            var productService = new ProductsService(mapperMock.Object, productRepositoryMock.Object,
                productDescriptionRepository, productPhotoRepositoryMock.Object);

            // Act
            var result = productService.GetProductsByName(searchingName);

            //// Assert
            Assert.IsType<Task<List<PartialProductDto>>>(result);
            Assert.Equal(2, result.Result.Count);
        }

        /// <summary>
        /// Gets the test products asynchronous.
        /// </summary>
        /// <returns></returns>
        private Task<List<Product>> GetTestProductsAsync()
        {
            return Task.Run(async () =>
            {
                await Task.Delay(100);
                return new List<Product>()
                {
                    new Product { ProductId= 1, Name="Touring-1000"},
                    new Product { ProductId= 2, Name="Touring-2000"}
                };
            });
        }

        /// <summary>
        /// Maps the product to partial product dto.
        /// </summary>
        /// <returns></returns>
        private List<PartialProductDto> MapProductToPartialProductDto()
        {
            var partialProductDto = new List<PartialProductDto>()
            {
                new PartialProductDto(){ ProductId= 1, ModelName= "Touring-1000" },
                new PartialProductDto(){ ProductId= 2, ModelName= "Touring2000" }
            };

            return partialProductDto;
        }

        /// <summary>
        /// Gets the products photos asynchronous.
        /// </summary>
        /// <returns></returns>
        private Task<Dictionary<int, ProductPhoto>> GetProductsPhotosAsync()
        {
            return Task.Run(async () =>
            {
                await Task.Delay(100);
                return new Dictionary<int, ProductPhoto>()
                {
                    { 1,
                        new ProductPhoto()
                        {
                            ThumbNailPhoto = new byte[] {}
                        }
                    },
                    {2,
                        new ProductPhoto()
                        {
                            ThumbNailPhoto = new byte[] {}
                        }
                    }
                };
            });
        }
    }
}
