import * as requests from '../../api/productApi';
import * as types from '../actionTypes'
import { apiErrorHandled } from '../errorActions/apiErrorActions';

export function getSubcategories() {
    return function (dispatch) {
        return requests.loadProductSubcategories().then(subCategories => {
            dispatch(subCategoriesLoaded(subCategories));
        }).catch(err => {
            dispatch(apiErrorHandled(err));
        });
    };
}

export function subCategoriesLoaded(subCategories) {
    return { type: types.SUBCATEGORIES_LOADED, subCategories };
}