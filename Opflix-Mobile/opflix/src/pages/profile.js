import React, {Component} from 'react';
import {Text, AsyncStorage,Image, StyleSheet , View} from 'react-native'

class Profile extends Component {

    static navigationOptions = {
        tabBarIcon: () => (
          <Image
            source={require('../assets/img/imagemCasa.png')}
            style={styles.tabBarNavigatorIcon}
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
          const tokenDoStorage = await AsyncStorage.getItem('@opflix:token');
          if (tokenDoStorage != null) {
            this.setState({token: tokenDoStorage});
          }
        } catch (error) {}
      };
    
      render() {
        return (
          <View>
            <Text>{this.state.token}</Text>
          </View>
        );
    }
}

    const styles = StyleSheet.create({
        tabBarNavigatorIcon: { width: 35, height: 35, tintColor: 'white' }
    });

export default Profile;