import * as requests from '../../api/productApi';
import * as types from '../actionTypes'
import { apiErrorHandled } from '../errorActions/apiErrorActions';

export function loadProductDetails(productId) {
    return function (dispatch) {
        return requests.loadProductDetails(productId).then((productDetails) => {
            dispatch(productDetailsLoaded(productDetails));
        }).catch(err => {
            dispatch(apiErrorHandled(err));
        });
    };
}

export function productDetailsLoaded(productDetails) {
    return { type: types.PRODUCT_DETAILS_LOADED, productDetails };
}

export function addedProductDisplayed() {
    return {type: types.ADDED_PRODUCT_DISPLAYED}
}