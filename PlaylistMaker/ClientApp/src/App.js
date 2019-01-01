import React, { Component } from 'react';
import { Route } from 'react-router';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import Button from './components/Button';
import ButtonAppBar from './components/ButtonAppBar';
import EnhancedTableHead  from './components/EnhancedTable';
import EnhancedTable  from './components/EnhancedTable';
import Layout  from './layouts/Layout';
import Login  from './pages/Login';
import Main  from './pages/Main';

export default class App extends Component {
  displayName = App.name
  constructor(props) {
    super(props);
    this.state = {
     
      homeLink:"login"
    };
  }
  componentDidMount() {
    fetch("api/SampleData/Login")
      .then(res => res.json())
      .then(
        (result) => {
          this.setState({
            isLoaded: true,
            items: result.items
          });
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        (error) => {
          this.setState({
            isLoaded: true,
            error
          });
        }
      )
  }

  render() {
    return (
      <div>
      <Layout homeLink={this.state.homeLink}/>
      <main>
      <Route path="/login" component={Login} />
      <Route path="/user" component={Main} />
      </main>
      </div>
    );
  }
}
