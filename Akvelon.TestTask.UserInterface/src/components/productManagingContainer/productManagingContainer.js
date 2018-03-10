import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import { updateProduct, addProduct } from '../../actions/productActions/productActions';
import ProductRedactionForm from './productRedactionForm';
import { run } from '../../validation/ruleRunner';
import { fieldValidationsRules } from '../../validation/productValidation/fieldValidationsRules';
import $ from "jquery";

class ProductManagingContainer extends Component {
    constructor(props) {
        super(props);
        this.state = {
            isAdding: this.props.isAdding,
            productDetails: this.props.productDetails,
            subCategories: this.props.subCategories,
            isButtonBlocked: false,
            isModalOpen: true,
            showErrors: false,
            validationErrors: {}
        };
        this.updateProductDetailsState = this.updateProductDetailsState.bind(this);
        this.saveProductDetails = this.saveProductDetails.bind(this);
        this.updateProductSubCategory = this.updateProductSubCategory.bind(this);
        this.updateProductImage = this.updateProductImage.bind(this);
        this.onBackClick = this.onBackClick.bind(this);
        this.errorFor = this.errorFor.bind(this);
    }

    componentWillMount() {
        // Run validations on initial state
        this.setState({ validationErrors: run(this.state.productDetails, fieldValidationsRules) });
    }

    componentWillReceiveProps(nextProps) {
        if (this.props.subCategories.length !== nextProps.subCategories.length) {
            return this.setState({ subCategories: nextProps.subCategories });
        }
        if (this.state.isAdding !== nextProps.isAdding) {
            return this.setState({ productDetails: nextProps.productDetails });
        }
    }

    saveProductDetails(event) {
        event.preventDefault();
        // If form has validation errors, show then
        this.setState({ showErrors: true });
        if ($.isEmptyObject(this.state.validationErrors) === false) return null;
        // Block save button until operation will complete
        this.setState({ isButtonBlocked: true });
        if (this.state.isAdding) {
            return this.props.addProduct(this.state.productDetails);
        }
        this.props.updateProduct(this.state.productDetails);
    }

    updateProductImage(imageSource) {
        const productDetails = this.state.productDetails;
        let largePhoto = imageSource.split(",");
        productDetails.largePhoto = largePhoto[1];
        this.validationNewData(productDetails);
    }

    updateProductSubCategory(event) {
        const productDetails = this.state.productDetails;
        productDetails.subcategoryName = event.label;
        productDetails.productSubcategoryId = event.value;
        this.validationNewData(productDetails);
    }

    updateProductDetailsState(event) {
        const field = event.target.name;
        let productDetails = this.state.productDetails;
        productDetails[field] = event.target.value;
        this.validationNewData(productDetails);
    }

    validationNewData(productDetails) {
        let validationErrors = this.state.validationErrors;
        validationErrors = run(productDetails, fieldValidationsRules);
        return this.setState({ productDetails: productDetails, validationErrors: validationErrors });
    }

    onBackClick() {
        if (this.state.isAdding) {
            return this.setState({ isModalOpen: false });
        }
        this.setState({ isModalOpen: false });
        this.props.onBackClick();
    }

    errorFor(field) {
        return this.state.validationErrors[field] || "";
    }

    render() {
        return (
            <ProductRedactionForm
                productDetails={this.state.productDetails}
                subCategories={this.state.subCategories}
                onChange={this.updateProductDetailsState}
                onSave={this.saveProductDetails}
                onSubCategoryChange={this.updateProductSubCategory}
                onImageChange={this.updateProductImage}
                onBackClick={this.onBackClick}
                isButtonBlocked={this.state.isButtonBlocked}
                isModalOpen={this.state.isModalOpen}
                showErrors={this.state.showErrors}
                errorFor={this.errorFor} />
        );
    }
};

ProductManagingContainer.propTypes = {
    productDetails: PropTypes.object.isRequired,
    subCategories: PropTypes.array.isRequired
};

function mapDispatchToProps(dispatch) {
    return {
        updateProduct: productDetails => {
            dispatch(updateProduct(productDetails))
        },
        addProduct: productDetails => {
            dispatch(addProduct(productDetails))
        }
    }
}

export default connect(
    null,
    mapDispatchToProps)
    (ProductManagingContainer);