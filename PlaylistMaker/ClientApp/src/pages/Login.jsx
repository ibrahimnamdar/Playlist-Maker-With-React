import React, { Component } from "react";
import Layout from "../layouts/Layout";
import Typography from "@material-ui/core/Typography";
import { withStyles } from "@material-ui/core/styles";
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import Button from "../components/Button";

export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      error: null,
      isLoaded: false,
      url: "sa",
      homeLink: "login"
    };
    const styles = {
      root: {
        width: "100%",
        maxWidth: 500
      }
    };
  }

  handleLoginClick(url) {
    window.location.href = url;
  }

  componentDidMount() {
    fetch("api/SampleData/Login")
      .then(res => res.json())
      .then(
        result => {
          this.setState({
            isLoaded: true,
            url: result
          });
          window.location.href = result;
        },
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
        <Typography
          style={{
            width: "100%",
            maxWidth: "500",
            textAlign: "center",
            padding: "5%"
          }}
          component="h2"
          variant="h1"
          gutterBottom
        >
          Welcome to Playlist Maker
        </Typography>
      </div>
    );
  }
}
