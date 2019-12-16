import React,{Component} from 'react';

import logo from '../../assets/img/imagem-opflix.png';

import Rodape from '../../components/Rodape/Rodape';

import {Link} from 'react-router-dom';

class Lancamento extends Component{

    constructor(){
        super();
        this.state = {
            lista: [],
            nome: '',
            tempoDuracao: '',
            dataLancamento: '',
            sinopse: '',
            idGenero:'',
            idTipoMetragem:'',
        };
    }

    
componentDidMount(){
    this.listaAtualizada();
}

listaAtualizada = () =>{
    fetch('http://192.168.4.221:5000/api/lancamentos', { 
        method: 'GET',
        headers: {
            'Content-Type' : 'application/json',
            'Accept' :'application/json',
            'Authorization' : 'Bearer ' + localStorage.getItem('usuario-opflix')
        }
    })
        .then(response => response.json())
        .then(data => this.setState({lista: data}))
        .catch(err => console.log(err));
}
adicionaItem = (event) => {
    event.preventDefault();
    console.log(this.state.nome);
    fetch('http://192.168.4.221:5000/api/lancamentos',{
        method: "POST",
        body: JSON.stringify({nome: this.state.nome}),
        headers: {
            "Content-Type": "application/json"
        }
    })
    .then(this.listaAtualizada())
    .catch(error => console.log(error))
}

adicionaLancamento = () =>{
    let valores_lista = this.state.lista;
    let lancamento = {nome: this.state.nome}

    valores_lista.push(lancamento);

    this.setState({lista: valores_lista});
}

atualizarNome = (event) =>{
    this.setState({nome: event.target.value})
    console.log(this.state);
}


render(){
    return(
    <div>
    <table className="tabela">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Título</th>
                        <th>Tempo de Duração</th>
                        <th>Data de Lançamento</th>
                        <th>Sinopse</th>
                        <th>Tipo</th>
                    </tr>
                </thead>

                <tbody>
                    {this.state.lista.map(element =>{
                        return(
                            <tr key={element.idLancamento}>
                                <td>{element.idLancamento}</td>
                                <td>{element.nome}</td>
                                <td>{element.tempoDuracao}</td>
                                <td>{element.dataLancamento}</td>
                                <td>{element.sinopse}</td>
                                <td>{element.idGenero}</td>
                                <td>{element.idTipoMetragem}</td>
                            </tr>
                        )
                    })}
                </tbody>
            </table> 

            <div>
                <p>
                <Link to="/mapa">Mapa</Link>
                </p>
            </div>

            <Rodape />
        </div>
        )
    }
}

export default Lancamento;