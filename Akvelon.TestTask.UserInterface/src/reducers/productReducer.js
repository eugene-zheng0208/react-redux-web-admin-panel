import * as types from '../actions/actionTypes';
import initialState from './initialState';

export default function productReducer(state = initialState.products,
    action) {
    switch (action.type) {
        case types.BICYCLES_LOADED:
            return action.products;
        case types.PRODUCTS_FOUND:
            return action.products;
        case types.PRODUCT_DELETED:
            return [
                ...state.filter(product => product.productId !== action.productId)
            ];
        case types.PRODUCT_ADDED:
        return [
            ...state.filter(product => product.productId !== action.addedProduct.productId),
            Object.assign({}, action.addedProduct)
          ]
        default:
            return state;
    }
} 