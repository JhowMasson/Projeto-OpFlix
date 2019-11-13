import React, {Component} from 'react';

import {
    Text,
    View,
    TextInput,
    TouchableOpacity,
    AsyncStorage,
    StyleSheet,
    Image,
    ImageBackground,
} from 'react-native';
import {
    Colors,
} from 'react-native/Libraries/NewAppScreen';

class SignIn extends Component {
    static navigationOptions= {
        hearder: null,
    };

    constructor() {
        super();
        this.state = {
            email: 'erik@email.com',
            senha: '123456',
        };
    }

    _realizarLogin = async () => {
        fetch('http://192.168.4.221:5000/api/login', {
            method : 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                email: this.state.email,
                senha: this.state.senha,
            }),
        })
            .then(resposta => resposta.json())
            .then(data => this._irParaHome(data.token))
            .catch(erro => console.warn('Algo deu Errado' + erro));
    };

    _irParaHome = async tokenRecebido => {
        if (tokenRecebido != null) {
          try {
            
            await AsyncStorage.setItem('@opflix:token', tokenRecebido);

            this.props.navigation.navigate('MainNavigator');
            } catch (error) {}
        }
    };

    render() {
        return (
            <ImageBackground source={require('../assets/img/FundoMobile.jpg')} style={{width: '100%', height: '100%',}}>

            <View style ={styles.body}>
                

                <Image source={require('../assets/img/imagem-opflix.png')}style={styles.imgOpflix}/>

                <View style={styles.ItensLogin}></View>
                <TextInput style={styles.textInput}
                
                placeholder="email"
                onChangeText={email => this.setState({email})}
                value={this.state.email}
                />
            <TextInput style={styles.textInput}
            placeholder="senha"
            onChangeText={senha => this.setState({senha})}
            value={this.state.senha}
            />
            <TouchableOpacity onPress={this._realizarLogin}>
                <Text style={styles.btnLogin}>Entre</Text>
                <Text>Ou</Text>
                <Text style={styles.btnLogin}>Cadastre-se</Text>
            </TouchableOpacity>

            
                
            
            </View>
            </ImageBackground>
        );
    }
}

const styles = StyleSheet.create({
  
  
    body: {
      flex: 1,
      justifyContent: 'center',
      alignItems: 'center',
      marginTop: 50,
      
    },
    imgOpflix: {
      marginTop: 0,
      width: 160,
      height: 85,
    },
    ItensLogin: {
      flex: 1,
      justifyContent: 'center',
      alignItems: 'center',
    //   marginTop: 20,
    //   width: '70%',
      borderRadius: 10,
      backgroundColor: '#191919',
    },
    textInput: {
      marginTop: 50,
      width: '70%',
      color: '#191919',
      borderRadius: 10,
      backgroundColor: '#fff',
    },
    btnLogin:{
      textAlign: "center",
      width: 162,
      height: 30,
      fontSize: 20,
      marginTop: 35,
      borderRadius: 10,
      color: '#fff',
      backgroundColor: '#DB202C',
    },
    // btnCad: {
    //   marginTop: 20,
    //   fontSize: 20,
    //   color: '#fff',
    // },
  });

export default SignIn;