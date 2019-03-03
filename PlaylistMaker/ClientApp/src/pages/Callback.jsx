import React, { Component } from "react";

class Callback extends Component {
  constructor(props) {
    const params = new URLSearchParams(props.location.search);
    const code = params.get("code");
    super(props);
    this.state = { code };
  }

  componentDidMount() {
    fetch("api/SampleData/GetToken?code=" + this.state.code)
      .then(res => res.json())
      .then(
        result => {
          localStorage.setItem("token", result);
          window.location.href = "/user";
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
    return <h3>You are getting redirected to the main page...</h3>;
  }
}

export default Callback;
