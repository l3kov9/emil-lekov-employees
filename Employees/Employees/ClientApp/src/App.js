import React, { Component } from 'react';
import { Layout } from './components/Layout';
import Admin from './components/Admin';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Admin />
      </Layout>
    );
  }
}
