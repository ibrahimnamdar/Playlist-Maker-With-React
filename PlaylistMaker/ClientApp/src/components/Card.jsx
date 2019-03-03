import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';

const styles = {
  card: {
    maxWidth: 100,
  },
  media: {
    height: 140,
  },
};



class CardComponent extends React.Component {

    componentDidMount() {
        console.log('I was triggered during componentDidMount'+JSON.stringify(this.props))
      }

    constructor(props) {
        super(props);
        this.state={
            classes:props,
            imageUrl:this.props.user.images
        };
        console.log("saa"+JSON.stringify(this.props.user));
        
        if(this.state.imageUrl && this.state.imageUrl.length){
            this.setState={
                imageUrl:this.props.user.images[0].url
                        }
                        console.log("saasdasa"+JSON.stringify(this.state.imageUrl));
        }
      }

  render(){ return(
    <Card style={{maxWidth: 300}} className={this.state.classes.card}>
      <CardActionArea>
        <CardMedia
          className={this.state.classes.media}
          
          image={this.state.imageUrl}
          title={this.props.user.display_name}
        />
        <CardContent>
          <Typography gutterBottom variant="h5" component="h2">
          {this.props.user.display_name}
          </Typography>
          <Typography component="p">
          {this.props.user.product}
          </Typography>
        </CardContent>
      </CardActionArea>
      <CardActions>
        <Button size="small" color="primary">
          Share
        </Button>
        <Button size="small" color="primary">
          Learn More
        </Button>
      </CardActions>
    </Card>
  );
}
}



export default withStyles(styles)(CardComponent);