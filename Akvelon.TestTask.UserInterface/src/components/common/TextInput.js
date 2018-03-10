import React, { Component } from 'react';
import OptionallyDisplayed from './OptionallyDisplayed.js';
import PropTypes from 'prop-types';

class TextInput extends Component {

  constructor(props) {
    super(props);
    this.shouldDisplayError = this.shouldDisplayError.bind(this);
  }

  shouldDisplayError() {
    return this.props.showError && this.props.errorText !== "";
  }

  render() {
    return (
      <div>
        <label className="ui big label" htmlFor={this.props.name}>{this.props.label}</label>
        <div className="field">
          <input
            type="text"
            name={this.props.name}
            className="ui input"
            placeholder={this.props.placeholder}
            value={this.props.value}
            onChange={this.props.onChange} />
        </div>
        <OptionallyDisplayed display={this.shouldDisplayError()}>
          <div className="validation-error">
            <span className="text">{this.props.errorText}</span>
          </div>
        </OptionallyDisplayed>
      </div>
    );
  }
};

TextInput.propTypes = {
  name: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  onChange: PropTypes.func.isRequired,
  placeholder: PropTypes.string,
  value: PropTypes.any,
  showError: PropTypes.bool.isRequired,
  errorText: PropTypes.string
};

export default TextInput; 