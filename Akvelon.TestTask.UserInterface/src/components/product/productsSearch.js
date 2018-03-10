import React from 'react';

const ProductsSearch = ({
  searchingName,
  isSearchingButtonBlocked,
  handleChange,
  handleSubmit,
  toggleAdd
  }) => {
  return (
    <div className="four column row">
      <label className="ui blue ribbon label">Find products by name: </label>
      <input className="ui input" type="text" value={searchingName} onChange={handleChange}
        required pattern="[^$ ][A-z 0-9_\- ]+" minLength="3" maxLength="20" />
      <div>
        <br />
        <button className="ui green button"
          onClick={handleSubmit}
          disabled={searchingName.length < 3 || isSearchingButtonBlocked}>
          Find products
          </button>
      </div>
      <div>
        <br />
        <button className="ui primary button" onClick={toggleAdd}>
          Add new product
          </button>
      </div>
    </div>
  );
};

export default ProductsSearch;