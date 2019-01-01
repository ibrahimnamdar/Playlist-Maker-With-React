import React, { Component } from 'react';
import Layout from '../layouts/Layout';
import Typography from '@material-ui/core/Typography';
import { withStyles } from '@material-ui/core/styles';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import Button from '../components/Button';


export default class Login extends Component {
  

  constructor(props) {
    const params = new URLSearchParams(props.location.search);
    const code = params.get('code'); 
    super(props);
    this.state = {
      error: null,
      isLoaded: false,
      code:code
    };
    const styles = {
      root: {
        width: '100%',
        maxWidth: 500,
      }
    };
  }

handleLoginClick(url){
window.location.href=url;
}

  componentDidMount() {
    fetch("api/SampleData/GetUser?code="+this.state.code)
      .then(res => res.json())
      .then(
        (result) => {
          this.setState({
            isLoaded: true,
            
          });
          window.location.href=result;
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
      <Typography style={{width: '100%', maxWidth: '500', textAlign: 'center', padding: "5%"}} component="h2" variant="h1" gutterBottom>
        Welcome to Playlist Maker
      </Typography>
      </div>
    );
  }
}
