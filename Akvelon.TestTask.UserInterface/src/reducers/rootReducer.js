import {combineReducers} from 'redux';
import products from './productReducer';
import productDetails from './productDetailsReducer';
import subCategories from './subCategoriesReducer';
import productAdded from './productAddingStateReducer';

const rootReducer = combineReducers({
    products,
    productDetails,
    subCategories,
    productAdded
})

export default rootReducer;