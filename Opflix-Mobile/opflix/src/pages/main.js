import React, {Component} from 'react';
import {Text, View, Image, StyleSheet, AsyncStorage, ImageBackground,} from 'react-native';
import {FlatList} from 'react-native-gesture-handler';
import { Colors } from 'react-native/Libraries/NewAppScreen';

class Main extends Component {
  
  static navigationOptions = {
    tabBarIcon: () => (
      <Image
        source={require('../assets/img/pipocaIcone.png')}
        style={styles.MenuNavegacao}
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
          <ImageBackground source={require('../assets/img/FundoMobile2.png')} style={{width: '100%', height: '100%',  opacity: 0.88 }}>


      <View style={styles.fundoDaTela}>
      <View>
      <Image source={require('../assets/img/imagem-opflix.png')}style={styles.imgOpflix}/>
      </View>

        <Text style={styles.TituloPagina}>Principais Lançamentos</Text>
        <FlatList data={this.state.lancamentos}
          keyExtractor={item => item.idLancamento}
          renderItem={({item}) => (
            <View style={styles.listaDadosFilme}>

            <Text style={styles.listaFilmes}>{item.nome}</Text>
            
            <Text style={styles.TituloSecao}>Sinopse:</Text><Text style={styles.dadosListaFilmes}>{item.sinopse}</Text>

            <Text style={styles.TituloSecao}>Genero:</Text><Text style={styles.dadosListaFilmes}>{item.idGeneroNavigation.nome}</Text>

            <Text style={styles.TituloSecao}>Tipo Metragem:</Text><Text style={styles.dadosListaFilmes}>{item.idTipoMetragemNavigation.nome}</Text>            

            <Text style={styles.TituloSecao}>Tempo de Duração:</Text><Text style={styles.dadosListaFilmes}>{item.tempoDuracao}</Text>
            
            <Text style={styles.TituloSecao}>Data de Lancamento:</Text><Text style={styles.dadosListaFilmes}>{item.dataLancamento}</Text>
            
            </View>          
          )}
          />
        </View>
      </ImageBackground>        
    );
  }
}
const styles = StyleSheet.create({
  MenuNavegacao: { width: 35, height: 35, tintColor: 'white' },

  fundoDaTela:{
    backgroundColor: Colors.black,
    height: '100%',

},
TituloPagina:{
  color: 'red',
  textAlign: 'center',
  fontSize: 20,
  marginTop: 0,
},
imgOpflix: {
  width: 280,
  height: 130,
  marginTop: 30,
  marginLeft: 64,     
},

listaFilmes:{
  flex: 1,
  justifyContent: 'space-between',
  fontSize: 20,
  color: '#fff',
  borderBottomColor: 'red',
  borderBottomWidth: 1,
  margin: 10,
  paddingBottom: 0,
},
listaDadosFilme:{
  width: 408,
  marginTop: 10,
  marginBottom: 32,
},
  dadosListaFilmes:{
  color: '#fff',
},
TituloSecao:{
fontSize:15,
color:'red',
}

});

export default Main;
