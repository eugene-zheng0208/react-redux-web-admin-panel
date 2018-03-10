import * as types from '../actionTypes';

export function apiErrorHandled(err) {
    return { type: types.API_ERROR_HANDLED, err };
}