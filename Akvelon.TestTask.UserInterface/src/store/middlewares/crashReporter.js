import * as types from '../../actions/actionTypes';

const crashReporter = store => next => action => {
    if (action.type === types.API_ERROR_HANDLED) {
        console.error('Caught an exception!', action.err);
    }
    try {
        return next(action); // dispatch
    } catch (err) {
        console.error('Caught an exception!', err);
        // send to crash reporting tool
    }
}

export default crashReporter;