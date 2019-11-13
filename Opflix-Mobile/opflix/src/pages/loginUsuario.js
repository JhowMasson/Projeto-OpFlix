// import React, {Component} from 'react';

// import {
//     Text,
//     View,
//     TextInput,
//     TouchableOpacity,
//     AsyncStorage,
// } from 'react-native';


// class LoginUsuario extends Component {
//     static navigationOptions= {
//         hearder: null,
//     };

//     constructor() {
//         super();
//         this.state = {
//             email: 'admin@email.com',
//             senha: null,
//         };
//     }

//     _realizarLogin = async () => {
//         fetch('http://192.168.4.221:5000/api/login', {
//             method : 'POST',
//             headers: {
//                 Accept: 'application/json',
//                 'Content-Type': 'application/json',
//             },
//             body: JSON.stringify({
//                 email: this.state.email,
//                 senha: this.state.senha,
//             }),
//         })
//             .then(resposta => resposta.json())
//             .then(data => this._irParaHome(data.token))
//             .catch(erro => CustomConsole.war('Algo deu Errado' + erro));
//     };

//     _irParaHome = async tokenRecebido => {
//         if (tokenRecebido != null) {
//           try {
//             // salvar essa informacao no asyncstorage
//             await AsyncStorage.setItem('@opflix:token', tokenRecebido);
//             // redirecionar
//             this.props.navigation.navigate('MainNavigator');
//             } catch (error) {}
//         }
//     };

//     render() {
//         return (
//             <View>
//                 <TextInput 
//                 placeholder="email"
//                 onChangeText={email => this.setState({email})}
//                 value={this.state.email}
//             />
//             <TextInput
//             placeholder="senha"
//             onChangeText={senha => this.setState({senha})}
//             value={this.state.senha}
//             />
//             <TouchableOpacity onPress={this._realizarLogin}>
//                 <Text>Login</Text>
//             </TouchableOpacity>
//             </View>
//         );
//     }
// }

// export default LoginUsuario;