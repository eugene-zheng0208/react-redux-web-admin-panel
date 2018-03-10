import * as requests from '../../api/productApi';
import * as types from '../actionTypes';
import { apiErrorHandled } from '../errorActions/apiErrorActions';

export function loadFiveTheMostPopularBicycles() {
    return function (dispatch) {
        return requests.loadFiveTheMostPopularBicycles().then(products => {
            dispatch(bicyclesLoaded(products));
        }).catch(err => {
            dispatch(apiErrorHandled(err));
        });
    };
}

export function bicyclesLoaded(products) {
    return { type: types.BICYCLES_LOADED, products };
}
