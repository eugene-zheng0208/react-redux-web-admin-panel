import * as requests from '../../api/productApi';
import * as types from '../actionTypes';
import { apiErrorHandled } from '../errorActions/apiErrorActions';

export function findProductsByName(name) {
    return function (dispatch) {
        return requests.findProductsByName(name).then(products => {
            dispatch(productsFound(products));
        }).catch(err => {
            dispatch(apiErrorHandled(err));
        });
    };
}

export function productsFound(products) {
    return { type: types.PRODUCTS_FOUND, products };
}

export function updateProduct(productDetails) {
    return function (dispatch) {
        return requests.updateProduct(productDetails).then(() => {
            dispatch(productUpdated(productDetails));
        }).catch(err => {
            dispatch(apiErrorHandled(err));
        });
    };
}

export function productUpdated(productDetails) {
    return { type: types.PRODUCT_UPDATED, productDetails }
}

export function addProduct(newProduct) {
    return function (dispatch) {
        return requests.addProduct(newProduct).then( addedProduct => {
            dispatch(productAdded(addedProduct));
        }).catch(err => {
            dispatch(apiErrorHandled(err));
        });
    };
}

export function productAdded(addedProduct) {
    return { type: types.PRODUCT_ADDED, addedProduct }
}

export function deleteProduct(productId) {
    return function (dispatch) {
        return requests.deleteProduct(productId).then(() => {
            dispatch(productDeleted(productId));
        }).catch(err => {
            dispatch(apiErrorHandled(err));
        });
    };
}

export function productDeleted(productId) {
    return { type: types.PRODUCT_DELETED, productId };
}