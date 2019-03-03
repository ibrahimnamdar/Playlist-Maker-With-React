import React, { Component } from "react";
import { Route } from "react-router";
import Layout from "./layouts/Layout";
import Login from "./pages/Login";
import Main from "./pages/Main";
import Callback from "./pages/Callback";

export default class App extends Component {
  displayName = App.name;
  constructor(props) {
    super(props);
    this.state = {
      homeLink: "login"
    };
  }
  componentDidMount() {
    fetch("api/SampleData/Login")
      .then(res => res.json())
      .then(
        result => {
          this.setState({
            isLoaded: true,
            items: result.items
          });
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        error => {
          this.setState({
            isLoaded: true,
            error
          });
        }
      );
  }

  render() {
    return (
      <div>
        <Layout homeLink={this.state.homeLink} />
        <main>
          <Route path="/login" component={Login} />
          <Route path="/user" component={Main} />
          <Route path="/callback" component={Callback} />
        </main>
      </div>
    );
  }
}
