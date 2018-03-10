import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import ProductDetails from './productDetails';
import { getSubcategories } from '../../actions/productActions/subCategoriesActions';
import ProductManagingContainer from '../productManagingContainer/productManagingContainer';
import OptionallyDisplayed from '../common/OptionallyDisplayed';

class ProductDetailsContainer extends Component {
    constructor(props) {
        super(props);
        this.state = {
            productDetails: this.props.productDetails,
            isProductDetailsOpen: true,
            isEditing: false
        };
        this.toggleEdit = this.toggleEdit.bind(this);
        this.stopProductEdditing = this.stopProductEdditing.bind(this);
        this.closeProductdetails = this.closeProductdetails.bind(this);
    }

    componentWillReceiveProps(nextProps) {
        if (this.props.productDetails.productId != nextProps.productDetails.productId) {
            return this.setState({
                productDetails: nextProps.productDetails,
                isEditing: false,
                isProductDetailsOpen: true
            });
        }
        // Update subcategories list if it changed
        if (this.props.subCategories.length !== nextProps.subCategories.length) {
            return this.setState({ subCategories: nextProps.subCategories });
        }
        // If product details successfully updated, hide product details editing window and open product details window with new data
        if (this.props.productDetails.productId === nextProps.productDetails.productId && this.state.isEditing) {
            return this.setState({
                isEditing: false,
                isProductDetailsOpen: true,
                productDetails: nextProps.productDetails
            });
        }
        // Show product details window with same data if product details didn't change 
        if (this.props.productDetails.productId === nextProps.productDetails.productId) {
            return this.setState({
                isProductDetailsOpen: true
            });
        }
    }

    toggleEdit() {
        if (this.props.subCategories.length === 0) {
            this.props.getSubcategories();
        }
        return this.setState({ isEditing: true, isProductDetailsOpen: false })
    }

    closeProductdetails() {
        this.setState({ isProductDetailsOpen: false });
    }

    stopProductEdditing() {
        this.setState({ isEditing: false, isProductDetailsOpen: true });
    }

    render() {
        if (this.state.isEditing) {
            return (
                <ProductManagingContainer
                    productDetails={this.props.productDetails}
                    subCategories={this.props.subCategories}
                    onBackClick={this.stopProductEdditing}
                    isAdding={false} />
            );
        }
        return (
            <OptionallyDisplayed display={this.state.productDetails.productId !== 0}>
                <ProductDetails
                    productDetails={this.props.productDetails}
                    toggleEdit={this.toggleEdit}
                    isProductDetailsOpen={this.state.isProductDetailsOpen}
                    closeProductdetails={this.closeProductdetails} />
            </OptionallyDisplayed>
        );
    };
}

ProductDetailsContainer.propTypes = {
    productDetails: PropTypes.object.isRequired,
    subCategories: PropTypes.array
};

function mapStateToProps(state, ownProps) {
    return { productDetails: state.productDetails, subCategories: state.subCategories }
}

function mapDispatchToProps(dispatch) {
    return {
        getSubcategories: () => {
            dispatch(getSubcategories());
        }
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps)
    (ProductDetailsContainer);