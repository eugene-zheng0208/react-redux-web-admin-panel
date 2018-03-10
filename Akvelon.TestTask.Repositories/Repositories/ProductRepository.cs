using System;
using Akvelon.TestTask.DataAccessLayer.Contexts;
using Akvelon.TestTask.DataAccessLayer.Entities;
using Akvelon.TestTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akvelon.TestTask.Repositories.Repositories
{
    /// <summary>
    /// Product repository
    /// </summary>
    /// <seealso cref="Akvelon.TestTask.Repositories.Interfaces.IProductRepository" />
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly IAdventureWorks2014Context _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ProductRepository(IAdventureWorks2014Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the full information about bicycle.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public async Task<Product> GetFullInformationAboutProduct(int productId)
        {
            var product = await _context.Product
                .Include(p => p.ProductModel)
                .Include(p => p.ProductSubcategory)
                .Include(p => p.ProductProductPhoto).ThenInclude(pph => pph.ProductPhoto)
                .Where(p => p.ProductId == productId)
                .FirstOrDefaultAsync();

            return product;
        }

        /// <summary>
        /// Gets the most popular products.
        /// </summary>
        /// <param name="productsCount">The products count.</param>
        /// <param name="productCategoryName">Name of the product category.</param>
        /// <returns></returns>
        public async Task<List<Product>> GetTheMostPopularProducts(int productsCount, string productCategoryName)
        {
            // In this section we are selecting all subCategory Ids which are chosen category, subcategories
            var productSubcategoriesIds = await _context.ProductSubcategory
                .Where(sc => sc.ProductCategory.Name == productCategoryName)
                .Select(sc => sc.ProductSubcategoryId)
                .ToListAsync();

            // In this section we are selecting all product models by product subCategory
            var allProducts = await _context.ProductModel
                .Include(pm => pm.Product)
                .ThenInclude(p => p.TransactionHistoryArchive)
                .Where(pm => pm.Product.FirstOrDefault(p =>
                                 productSubcategoriesIds.Contains(p.ProductSubcategoryId.GetValueOrDefault())
                             ) != null)
                .ToListAsync();

            //In this section we are sorting out product models by transactions count and are selecting information
            //about product for each of five the most popular products  
            var theMostPopularProducts = allProducts
                .OrderByDescending(pm => pm.Product.Sum(p => p.TransactionHistoryArchive.Count))
                .Take(productsCount)
                .Select(pm => pm.Product.First())
                .ToList();

            return theMostPopularProducts;
        }

        /// <summary>
        /// Gets products by name.
        /// </summary>
        /// <param name="productName">Name of the product.</param>
        /// <returns></returns>
        public async Task<List<Product>> GetProductsByName(string productName)
        {
            var products = await _context.Product
                .Include(p => p.ProductModel)
                .Where(p => p.ProductModel.Name.Trim(' ').IndexOf(productName, StringComparison.OrdinalIgnoreCase) >= 0)
                .GroupBy(p => p.ProductModelId)
                .Select(gp => gp.First())
                .ToListAsync();

            return products;
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task DeleteProduct(Product product)
        {
            _context.Product.Remove(product);
            await _context.SaveAsync();
        }

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<Product> GetProductById(int productId)
        {
            var product = await _context.Product
                .Include(p => p.ProductModel)
                .FirstOrDefaultAsync(p => p.ProductId == productId);

            return product;
        }
    }
}