import React from 'react';
import ProductsSearch from './productsSearch';
import Product from './product';

const ProductList = ({
  products,
  onProductClick,
  deleteProduct,
  searchingName,
  handleSubmit,
  handleChange,
  toggleAdd,
  isSearchingButtonBlocked
    }) => {
  return (
    <div className="ui grid">
      <div className="eight widecolumn">
        <br />
        <h1 className="ui blue header">Welcome to bicycles shop</h1>
        <ProductsSearch
          searchingName={searchingName}
          isSearchingButtonBlocked={isSearchingButtonBlocked}
          handleChange={handleChange}
          handleSubmit={handleSubmit}
          toggleAdd={toggleAdd} />
        <table className="ui celled padded table">
          <thead>
            <tr className="ui center aligned header">
              <th>Photo</th>
              <th>Name</th>
              <th>Price</th>
              <th>Color</th>
              <th>Size</th>
              <th>Weight</th>
            </tr>
          </thead>
          <tbody>
            {products.map(product =>
              <Product
                product={product}
                onProductClick={onProductClick}
                deleteProduct={deleteProduct}
                key={product.productId} />
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default ProductList; 