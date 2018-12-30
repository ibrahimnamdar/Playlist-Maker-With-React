import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import Button from './components/Button';
import ButtonAppBar from './components/ButtonAppBar';
import EnhancedTableHead  from './components/EnhancedTable';
import EnhancedTable  from './components/EnhancedTable';
import LoginForm  from './components/LoginForm';

export default class App extends Component {
  displayName = App.name

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
      <ButtonAppBar/>        
      <Button />
      </div>
    );
  }
}
