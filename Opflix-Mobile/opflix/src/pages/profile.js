import React, {Component} from 'react';
import {Text, View, Image, StyleSheet, AsyncStorage, ImageBackground,} from 'react-native'

class Profile extends Component {

    static navigationOptions = {
        tabBarIcon: () => (
          <Image
            source={require('../assets/img/iconePerfil.png')}
            style={styles.IconePessoa}
          />
        )
      }
    

    constructor() {
        super();
        this.state = {
          token: null,
        };
      }
    
      componentDidMount() {
        this._buscarDadosDoStorage();
      }
    
      _buscarDadosDoStorage = async () => {
        try {
          const tokenStorage = await AsyncStorage.getItem('@opflix:token');
          if (tokenStorage != null) {
            this.setState({token: tokenStorage});
          }
        } catch (error) {}
      };
    
      render() {
        return (
          <ImageBackground source={require('../assets/img/fundomobiletres.jpg')} style={{width: '100%', height: '100%', backgroundColor: 'rgba(0, 0, 0, 0.2'}}>
            <View>
              <Text style={styles.aporradoitem}>{this.state.token}</Text>
            </View>
          </ImageBackground>
        );
    }
}

  const styles = StyleSheet.create({
    IconePessoa: { width: 35, height: 35, tintColor: 'white' },
    aporradoitem: {fontSize: 20, color: '#FFF'}
  
  });
    

export default Profile;