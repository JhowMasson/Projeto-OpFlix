import React,{Component} from 'react';

import logo from '../../assets/img/imagem-opflix.png';

import {Link} from 'react-router-dom';
import Axios from 'axios';


class Login extends Component{
    constructor(){
        super();
        this.state = {
            email: "",
            senha: "",
            erro: ""
        }
    }

    atualizaEstadoEmail = (event) =>{
        this.setState({email: event.target.value});
    }

    atualizaEstadoSenha = (event) =>{
        this.setState({senha: event.target.value});
    }

    efetuarLogin = (event) =>{
        event.preventDefault();

        Axios.post("http://192.168.4.221:5000/api/login", {
            email: this.state.email,
            senha: this.state.senha
        })
            .then(response => {
                if(response.status === 200){
                    console.log(response.data.token);
                    localStorage.setItem("usuario-opflix", response.data.token);
                    this.props.history.push('/lancamentos');
                }else{
                    console.log('Algo deu errado');
                }
            })
            .catch(erro => {
                this.setState({ erro: "Usuário ou senha estão inválidos"});
                console.log(erro);
            });
    }

    render(){
        return(
            
        <section className="login-usuario">

            <div className="item__login">
                <div className="row">
                <div className="item">
                    <Link to="/"><img id="login-img" src={logo}/></Link>
                </div>
                <div className="item" id="item__title">
                    <p id="introducao-login">
                    Bem-vindo! Faça o login para acessar sua conta.
                    </p>
                </div>
                <div id="estilo-login">
                <form onSubmit={this.efetuarLogin}>
                    <div className="item-login">
                    <input
                        className="login_usuario"
                        placeholder="usuario"
                        onChange={this.atualizaEstadoEmail}
                        type="text"
                        name="username"
                        id="login-email"
                    />
                    <p 
                        className="text__login"
                        style={{color: "red", textAlign: "center"}}
                    >
                        {this.state.erro}
                    </p>
                    </div>
                    <div className="item-login">
                    <input
                        className="login_usuario"
                        onInput={this.atualizaEstadoSenha}
                        placeholder="senha"
                        type="password"
                        name="password"
                        id="login-senha"
                    />
                    </div>
                    <div className="botao-login">
                    <button className="btn_login">
                        Login
                    </button>
                    </div>
                </form>
                </div>
                </div>
            </div>
            </section>

        );
    }

}

export default Login;