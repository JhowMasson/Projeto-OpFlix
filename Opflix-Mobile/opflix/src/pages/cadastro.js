import React, {Component} from 'react';

class Cadastro extends Component {
    static navigationOptions = {
        header: null,
    };

    constructor() {
        super();
        this.state = {
            
        };
    }


    render() {
        return (
            <imageBackground source={require('../assets/img/iconeAlerta.png')} style={{width: '20%', height:'20%'}}></imageBackground>
            
        );
    }
}

export default Cadastro;