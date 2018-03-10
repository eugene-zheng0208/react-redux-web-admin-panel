import React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';
import ProductListContainer from './components/product/productListContainer';
import App from './components/App';
import ProductDetailsContainer from './components/productDetails/productDetailsContainer';

const Routing = () => {
    return (
        <BrowserRouter>
            <div>
                <Route exact path="/" component={ App } />
                <Route path="/products" component={ ProductListContainer }/>
                <Route path="/products/:id" component={ ProductDetailsContainer }/>
            </div>
        </BrowserRouter>
    )
}

export default Routing;
