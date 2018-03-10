import React from 'react';
import { Modal, Header } from 'semantic-ui-react'

const ProductDetails = ({
    productDetails,
    toggleEdit,
    isProductDetailsOpen,
    closeProductdetails
    }) => {
    return (
        <Modal size='tiny' open={isProductDetailsOpen}>
            <Header icon='archive' content={productDetails.name} />
            <Modal.Content>
                <p>Model: {productDetails.modelName} </p>
                <p>Color: {productDetails.color} </p>
                <p>Size: {productDetails.size} </p>
                <p>Weight: {productDetails.weight} </p>
                <p>Category: {productDetails.subcategoryName} </p>
                <p>Description: {productDetails.description} </p>
                <p>Price: {productDetails.listPrice}</p>
                <p>
                    <img src={'data:image/png;base64,' + productDetails.largePhoto} />
                </p>
            </Modal.Content>
            <Modal.Actions>
                <button className="ui red button" onClick={closeProductdetails}>Back</button>
                <button className="ui yellow button" onClick={toggleEdit}>Edit product</button>
            </Modal.Actions>
        </Modal>
    );
}

export default ProductDetails;