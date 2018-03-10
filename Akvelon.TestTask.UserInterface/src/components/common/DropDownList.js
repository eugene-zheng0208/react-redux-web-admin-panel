import React, { Component } from 'react';
import PropTypes from 'prop-types';
import Dropdown from 'react-dropdown';
import OptionallyDisplayed from './OptionallyDisplayed.js';

class DropDownList extends Component {
  constructor(props) {
    super(props)
    this.state = {
      productDetails: this.props.productDetails,
      subCategories: this.props.subCategories,
      subCategoryName: this.props.subCategoryName,
      options: [],
      value: this.props.value
    }
    this.shouldDisplayError = this.shouldDisplayError.bind(this);
  }

  componentWillReceiveProps(nextProps) {
    if (this.props.subCategories.length < 1) {
      var options = this.state.options;
      var temObj = { value: 0, label: '' };
      options = nextProps.subCategories.map(subCategory => {
        temObj.value = subCategory.productSubcategoryId;
        temObj.label = subCategory.name;
        return Object.assign({}, temObj)
      });
      if (this.state.value !== '') {
        var value = this.state.value;
        value = options.find(option => option.label === this.state.value);
        this.setState({ options: options, value: value })
      }
      this.setState({ options: options });
      return;
    }
    var value = this.state.value;
    value = this.state.options.find(option => option.label === nextProps.value);
    this.setState({ value: value })
  }

  shouldDisplayError() {
    return this.props.showError && this.props.errorText !== "";
  }

  render() {
    return (
      <div>
        <label className="ui big label" htmlFor={this.props.name}>{this.props.label}</label>
        <Dropdown
          options={this.state.options}
          onChange={this.props.onChange}
          value={this.state.value}
          placeholder={this.props.placeholder} />
        <OptionallyDisplayed display={this.shouldDisplayError()}>
          <div className="validation-error">
            <span className="text">{this.props.errorText}</span>
          </div>
        </OptionallyDisplayed>
      </div>
    );
  }
};

DropDownList.propTypes = {
  onChange: PropTypes.func.isRequired,
  placeholder: PropTypes.string,
  options: PropTypes.array,
  showError: PropTypes.bool.isRequired,
  errorText: PropTypes.string
};

export default DropDownList; 