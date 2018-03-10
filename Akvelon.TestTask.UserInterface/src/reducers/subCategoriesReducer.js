import * as types from '../actions/actionTypes';
import initialState from './initialState';

export default function subCategoriesReducer(state = initialState.subCategories,
    action) {
    switch (action.type) {
        case types.SUBCATEGORIES_LOADED:
        debugger;
            return action.subCategories;
        default:
            return state;
    }
} 