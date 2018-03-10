import React from 'react';
import ReactDOM from 'react-dom';
import Routing from './routing';
import configureStore from './store/configureStore';
import { Provider } from 'react-redux';
import App from './components/App';

const store = configureStore();

ReactDOM.render(
  <Provider store={store}>
    <Routing>
      <App />
    </Routing>
  </Provider>
  , document.getElementById('root')
);