import { createStore, applyMiddleware } from 'redux';
import rootReducer from '../reducers/rootReducer';
import thunk from 'redux-thunk';
import crashReporter from './middlewares/crashReporter';

export default function configureStore() {
    return createStore(
        rootReducer,
        applyMiddleware(crashReporter, thunk)
    );
}
