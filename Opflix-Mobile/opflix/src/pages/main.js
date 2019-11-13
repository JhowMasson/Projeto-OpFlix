import React, {Component} from 'react';
import {Text, View, Image, StyleSheet, AsyncStorage } from 'react-native';
import {FlatList} from 'react-native-gesture-handler';
import { Colors } from 'react-native/Libraries/NewAppScreen';

class Main extends Component {
  
  static navigationOptions = {
    tabBarIcon: () => (
      <Image
        source={require('../assets/img/pipocaIcone.png')}
        style={styles.tabBarNavigatorIcon}
      />
    )
  }

    constructor() {
      super();
      this.state = {
        lancamentos: [],
      };
  }

    componentDidMount() {
      this._carregarLancamentos();
  }

  _carregarLancamentos = async () => {
    try {

      let token = await AsyncStorage.getItem('@opflix:token');

      await fetch('http://192.168.4.221:5000/api/lancamentos', {
        headers: {
          'Authorization' : 'Bearer ' + token,
          'Content-Type' : 'application/json'
        }
      })
        .then(resposta => resposta.json())
        .then(data => this.setState({ lancamentos: data }))
        .catch(erro => console.warn(erro));
    } catch (error) {}
  };

  render() {
        return (

    <View style={styles.body}>
        <FlatList data={this.state.lancamentos}
          keyExtractor={item => item.idLancamento}
          renderItem={({item}) => (
        <View>
            <Text style={styles.listaFilmes}>{item.nome}</Text>
            
            <Text style={styles.dadosListaFilmes}>{item.sinopse}</Text>

            <Text style={styles.dadosListaFilmes}>{item.idGenero}</Text>

            <Text style={styles.dadosListaFilmes}>
            {item.idTipoMetragem}</Text>            

            <Text style={styles.dadosListaFilmes}>{item.tempoDuracao}</Text>
            
            <Text style={styles.dadosListaFilmes}>{item.dataLancamento}</Text>
            
            </View>          
          )}
        />
      </View>          
    );
  }
}
const styles = StyleSheet.create({
  tabBarNavigatorIcon: { width: 35, height: 35, tintColor: 'white' },

  body:{
    backgroundColor: Colors.black,
},

listaFilmes:{
    color: '#fff',
    borderBottomColor: 'red',
    borderBottomWidth: 1,
    margin: 10,
    paddingBottom: 2,
},
dadosListaFilmes:{
    color: '#fff',
},

});

export default Main;
