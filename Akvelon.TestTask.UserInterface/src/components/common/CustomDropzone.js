import React, { Component } from 'react';
import PropTypes from 'prop-types';
import Dropzone from 'react-dropzone';
import OptionallyDisplayed from './OptionallyDisplayed.js';

class CustomDropzone extends Component {
  constructor(props) {
    super(props)
    this.state = {
      value: this.props.value
    }
    this.shouldDisplayError = this.shouldDisplayError.bind(this);
  }

  componentWillMount() {
    if (this.props.value !== '') {
      let value = this.state.value;
      value = 'data:image/png;base64,' + this.props.value;
      this.setState({ value: value });
    }
  }

  onDrop(imageFiles) {
    let file = imageFiles[0];
    let value = this.state.value;
    const reader = new FileReader();
    // Load image source from stream
    reader.onload = () => {
      value = reader.result;
      this.setState({
        imageFiles: imageFiles, value: value
      });
      this.props.onImageChange(this.state.value);
    };
    reader.readAsDataURL(file);
  }

  shouldDisplayError() {
    return this.props.showError && this.props.errorText !== "";
  }

  render() {
    return (
      <div>
        <label className="ui big label">Photo</label>
        <Dropzone onDrop={this.onDrop.bind(this)}
          className='dropzone'
          activeClassName='active-dropzone'
          multiple={false}
          id='dropzone'>
          <p>Try dropping some files here, or click to select files to upload.</p>
        </Dropzone>
        <OptionallyDisplayed display={this.shouldDisplayError()}>
          <div className="validation-error">
            <span className="text">{this.props.errorText}</span>
          </div>
        </OptionallyDisplayed>
        <OptionallyDisplayed display={this.state.value !== ''}>
          <div>
            <img src={this.state.value} />
          </div>
        </OptionallyDisplayed>
      </div>
    );
  }
};

CustomDropzone.propTypes = {
  onImageChange: PropTypes.func.isRequired,
  value: PropTypes.string
};

export default CustomDropzone;