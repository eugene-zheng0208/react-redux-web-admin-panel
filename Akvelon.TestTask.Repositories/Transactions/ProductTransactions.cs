using Akvelon.TestTask.DataAccessLayer.Contexts;
using Akvelon.TestTask.DataAccessLayer.Entities;
using Akvelon.TestTask.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Akvelon.TestTask.Repositories.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Akvelon.TestTask.Repositories.Interfaces.IProductTransactions" />
    public class ProductTransactions : IProductTransactions
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly AdventureWorks2014Context _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTransactions"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ProductTransactions(AdventureWorks2014Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="photos">The photos.</param>
        /// <param name="productProductPhotos">The product product photos.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task DeleteProduct(Product product, List<ProductPhoto> photos, List<ProductProductPhoto> productProductPhotos)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.ProductProductPhoto.RemoveRange(productProductPhotos);
                    await _context.SaveChangesAsync();

                    _context.ProductPhoto.RemoveRange(photos);
                    await _context.SaveChangesAsync();

                    _context.Product.Remove(product);
                    await _context.SaveChangesAsync();

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="productDescription">The product description.</param>
        /// <param name="productPhoto">The product photo.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task EditProduct(Product product, ProductDescription productDescription, ProductPhoto productPhoto)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Product.Update(product);
                    await _context.SaveChangesAsync();

                    if (productDescription != null)
                    {
                        _context.ProductDescription.Update(productDescription);
                        await _context.SaveChangesAsync();
                    }

                    if (productPhoto != null)
                    {
                        _context.ProductPhoto.Update(productPhoto);
                        await _context.SaveChangesAsync();
                    }

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="productModel">The product model.</param>
        /// <param name="productDescription">The product description.</param>
        /// <param name="productPhoto">The product photo.</param>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        public async Task<Product> AddProduct(Product product, ProductModel productModel, ProductDescription productDescription,
           ProductPhoto productPhoto, Culture culture)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Adding new product description
                    var newProductDescription = await _context.ProductDescription.AddAsync(productDescription);
                    await _context.SaveChangesAsync();

                    // Adding new productmodel
                    var newProductModel = await _context.ProductModel.AddAsync(productModel);
                    await _context.SaveChangesAsync();

                    //// Adding relationship between new productmodel and new product description
                    await _context.ProductModelProductDescriptionCulture.AddAsync(new ProductModelProductDescriptionCulture()
                    {
                        ProductModelId = newProductModel.Entity.ProductModelId,
                        ProductDescriptionId = newProductDescription.Entity.ProductDescriptionId,
                        CultureId = culture.CultureId
                    });
                    await _context.SaveChangesAsync();

                    // Adding new product
                    product.ProductModelId = newProductModel.Entity.ProductModelId;
                    var newProduct = _context.Product.Add(product);
                    _context.SaveChanges();

                    // Adding new photos
                    var newProductPhoto = _context.ProductPhoto.Add(productPhoto);
                    _context.SaveChanges();

                    // Adding relationship between new product and new product photo
                    _context.ProductProductPhoto.Add(new ProductProductPhoto()
                    {
                        ProductId = newProduct.Entity.ProductId,
                        ProductPhotoId = newProductPhoto.Entity.ProductPhotoId,
                    });
                    _context.SaveChanges();

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();

                    return newProduct.Entity;
                }
                catch (Exception e)
                {
                    throw e.InnerException;
                }
            }
        }
    }
}
