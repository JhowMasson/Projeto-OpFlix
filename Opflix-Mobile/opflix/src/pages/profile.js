import React, {Component} from 'react';
import {Text, View, Image, StyleSheet, AsyncStorage, ImageBackground,} from 'react-native'
import jwtDecode from 'jwt-decode';

class Profile extends Component {

  static navigationOptions = {
    tabBarIcon: () => (
        <Image
          source={require('../assets/img/iconePerfil.png')}
          style={styles.MenuNavegacao}
        />
      )
    }
  

  constructor() {
      super();
      this.state = {
      token: null,
  };
}


    componentDidMount(){
      this._emailUsuario();
    }

    _emailUsuario = async () =>{
      try{
        let resultEmail = await AsyncStorage.getItem("@opflix:token");
        let usuario = jwtDecode(resultEmail);
        let email = usuario.email
        this.setState({ token: email})
      }catch(error){}
    }

    render() {
      return (
        <ImageBackground source={require('../assets/img/fundomobiletres.jpg')} style={{width: '100%', height: '100%', backgroundColor: 'rgba(0, 0, 0, 0.2'}}>

        <View style={styles.ItensLogin}></View>

          <Image source={require('../assets/img/imagem-opflix.png')}style={styles.imgOpflix}/>
          <Text style={styles.welcomeProfile}>Bem Vindo(a) ao seu Perfil</Text>
          <View>
            <Text style={styles.item}>{this.state.token}</Text>
          </View>
        </ImageBackground>
    );
  }
}

  const styles = StyleSheet.create({
    MenuNavegacao: { 
      width: 35,
      height: 35,
      tintColor: 'white',
    },

    item: {
      fontSize: 25,
      color: '#FFF',
      textAlign:'center',
      padding: 60,
    },

    welcomeProfile: {
      color: 'red',
      textAlign: 'center',
      fontSize: 25,
      marginTop: 100,
    },

    imgOpflix: {
      width: 280,
      height: 130,
      marginLeft: 60,     
  },

    ItensLogin: {
      justifyContent: 'center',
      alignItems: 'center',
    },
  
  });
    

export default Profile;