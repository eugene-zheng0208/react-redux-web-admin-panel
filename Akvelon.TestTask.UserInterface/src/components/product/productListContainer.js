import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import ProductList from './productList';
import { loadProductDetails, addedProductDisplayed } from '../../actions/productActions/productDetailsActions';
import { getSubcategories } from '../../actions/productActions/subCategoriesActions';
import { loadFiveTheMostPopularBicycles } from '../../actions/bicyclesActions/bicyclesActions';
import { findProductsByName, deleteProduct } from '../../actions/productActions/productActions';
import ProductManagingContainer from '../productManagingContainer/productManagingContainer';
import OptionallyDisplayed from '../common/OptionallyDisplayed';

class ProductListContainer extends Component {
    constructor(props) {
        super(props);

        this.state = {
            isAdding: false,
            searchingName: '',
            isSearchingButtonBlocked: true
        };
        this.toggleAdd = this.toggleAdd.bind(this);
        this.searchingNameChange = this.searchingNameChange.bind(this);
        this.findProducts = this.findProducts.bind(this);
    }

    componentWillMount() {
        this.props.getBicycles();
    }

    componentWillReceiveProps(nextProps) {
        if (this.props.products.length === 0 || nextProps.products.length === 0) {
            this.setState({ isSearchingButtonBlocked: false });
        }
        if (nextProps.productAdded) {
            this.setState({ isAdding: false});
        }
    }

    searchingNameChange(event) {
        this.setState({ searchingName: event.target.value });
    }

    toggleAdd() {
        this.props.getSubcategories();
        this.setState({ isAdding: true })
    }

    findProducts(event) {
        this.props.findProductsByName(this.state.searchingName);
        this.setState({ isSearchingButtonBlocked: true });
    }

    render() {
        return (
            <div>
                <ProductList products={this.props.products}
                    searchingName={this.state.searchingName}
                    onProductClick={this.props.onProductClick}
                    handleSubmit={this.findProducts}
                    toggleAdd={this.toggleAdd}
                    deleteProduct={this.props.deleteProduct}
                    handleChange={this.searchingNameChange}
                    isSearchingButtonBlocked={this.state.isSearchingButtonBlocked} />
                <OptionallyDisplayed display={this.state.isAdding}>
                    <ProductManagingContainer
                        isAdding={this.state.isAdding}
                        subCategories={this.props.subCategories}
                        productDetails={this.props.productDetails} />
                </OptionallyDisplayed>
            </div>
        );
    }
}

ProductListContainer.propTypes = {
    products: PropTypes.array.isRequired
};

function mapDispatchToProps(dispatch) {
    return {
        getBicycles: () => {
            dispatch(loadFiveTheMostPopularBicycles());
        },
        onProductClick: productId => {
            dispatch(loadProductDetails(productId))
        },
        findProductsByName: name => {
            dispatch(findProductsByName(name))
        },
        getSubcategories: () => {
            dispatch(getSubcategories());
        },
        deleteProduct: productId => {
            dispatch(deleteProduct(productId))
        }
    }
}

function mapStateToProps(state) {
    let productDetails = {
        productId: 0,
        modelName: '',
        name: '',
        color: '',
        listPrice: 0,
        size: '',
        weight: 0,
        productSubcategoryId: 0,
        subcategoryName: '',
        description: '',
        largePhoto: ''
    };
    return {
        products: state.products,
        subCategories: state.subCategories,
        productDetails: productDetails,
        productAdded: state.productAdded
    };
}

export default connect(
    mapStateToProps,
    mapDispatchToProps)
    (ProductListContainer); 