import React, { Component } from 'react';
import TextInput from '../common/TextInput';
import CustomDropzone from '../common/CustomDropzone';
import DropDownList from '../common/DropDownList';
import { Modal, Header } from 'semantic-ui-react'

const ProductRedactionForm = ({
    productDetails,
    subCategories,
    onChange,
    onSubCategoryChange,
    onSave,
    onImageChange,
    isButtonBlocked,
    onBackClick,
    isModalOpen,
    showErrors,
    errorFor
     }) => {
    return (
        <Modal size='tiny' open={isModalOpen}>
            <Header icon='archive' content="Product info" />
            <Modal.Content>
                <div>
                    <br />
                    <TextInput
                        name="name"
                        label="name"
                        value={productDetails.name}
                        onChange={onChange}
                        showError={showErrors}
                        errorText={errorFor("name")} />
                </div>
                <div>
                    <br />
                    <TextInput
                        name="modelName"
                        label="Model Name"
                        value={productDetails.modelName}
                        onChange={onChange}
                        showError={showErrors}
                        errorText={errorFor("modelName")} />
                </div>
                <div>
                    <br />
                    <TextInput
                        name="color"
                        label="color"
                        value={productDetails.color}
                        onChange={onChange}
                        showError={showErrors}
                        errorText={errorFor("color")} />
                </div>
                <div>
                    <br />
                    <TextInput
                        name="size"
                        label="size"
                        value={productDetails.size}
                        onChange={onChange}
                        showError={showErrors}
                        errorText={errorFor("size")} />
                </div>
                <div>
                    <br />
                    <TextInput
                        name="weight"
                        label="weight"
                        value={productDetails.weight}
                        onChange={onChange}
                        showError={showErrors}
                        errorText={errorFor("weight")} />
                </div>
                <div>
                    <br />
                    <DropDownList
                        name="subcategoryName"
                        label="Subcategory"
                        subCategories={subCategories}
                        onChange={onSubCategoryChange}
                        value={productDetails.subcategoryName}
                        placeholder="Select subcategory"
                        showError={showErrors}
                        errorText={errorFor("subcategoryName")} />
                </div>
                <div>
                    <br />
                    <TextInput
                        name="description"
                        label="description"
                        value={productDetails.description}
                        onChange={onChange}
                        showError={showErrors}
                        errorText={errorFor("description")} />
                </div>
                <div>
                    <br />
                    <TextInput
                        name="listPrice"
                        label="Price"
                        value={productDetails.listPrice}
                        onChange={onChange}
                        showError={showErrors}
                        errorText={errorFor("listPrice")} />
                </div>
                <div>
                    <br />
                    <CustomDropzone
                        name="largePhoto"
                        value={productDetails.largePhoto}
                        onImageChange={onImageChange}
                        showError={showErrors}
                        errorText={errorFor("largePhoto")} />
                </div>
            </Modal.Content>
            <Modal.Actions>
                <button
                    className="ui red button"
                    onClick={onBackClick}>
                    Back
                </button>
                <button
                    className="ui green button"
                    disabled={isButtonBlocked}
                    onClick={onSave}>
                    Save
                </button>
            </Modal.Actions>
        </Modal>
    );
}

export default ProductRedactionForm;