import * as types from '../actions/actionTypes';
import initialState from './initialState';

export default function productDetailsReducer(state = initialState.productDetails,
    action) {
    switch (action.type) {
        case types.PRODUCT_DETAILS_LOADED:
            return action.productDetails;
        case types.PRODUCT_UPDATED:
            return Object.assign({}, action.productDetails);
        default:
            return state;
    }
} 