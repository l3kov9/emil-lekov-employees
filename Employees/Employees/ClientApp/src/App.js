import React, { Component } from 'react';
import { Layout } from './components/Layout';
import EmployeesTable from './components/EmployeesTable.js';
import Admin from './components/Admin';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Admin />
        <EmployeesTable />
      </Layout>
    );
  }
}
