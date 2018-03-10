import React from 'react';
import { Link } from 'react-router-dom';

const Product = ({ product, onProductClick, deleteProduct }) => {
    return (
        <tr className="ui center aligned">
            <td>
                <img src={'data:image/png;base64,' + product.thumbNailPhoto} />
            </td>
            <td>
                <Link to={'/products/' + product.productId} onClick={() => onProductClick(product.productId)}>
                    {product.modelName}
                </Link>
            </td>
            <td>Price: {product.listPrice}</td>
            <td>Color: {product.color}</td>
            <td>Size: {product.size}</td>
            <td>Weight: {product.weight}</td>
            <td><button className="ui red button"
                onClick={() => deleteProduct(product.productId)}>Delete
                </button></td>
        </tr>
    );
}

export default Product;