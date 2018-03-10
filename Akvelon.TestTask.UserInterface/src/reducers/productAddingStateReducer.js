import * as types from '../actions/actionTypes';
import initialState from './initialState';

export default function productAddingStateReducer(state = initialState.productAdded,
    action) {
    switch (action.type) {
        case types.PRODUCT_ADDED:
            return true;
        case types.ADDED_PRODUCT_DISPLAYED:
            return false;
        default:
            return state;
    }
} 