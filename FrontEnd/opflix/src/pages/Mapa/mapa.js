import React,{Component} from 'react';

import GoogleMapReact from 'google-map-react';

import PinLocalizacao from '../../assets/img/localizacaoPin.png';

import '../../assets/CSS/mapa.css';





const Local =({lancamento}) => <div> 
    <img src={PinLocalizacao} alt="" className="pinLocalizacao" />
    <p>{lancamento.nome}</p> 
    </div>


class Mapa extends Component{

    constructor(){
      super();
      this.state = {
          localizacoes: [],

      }
    }

    static defaultProps = {
        center: {
          lat: 13.5364985,
          lng: -46.6483357
        },
        zoom: 1
      };

      componentDidMount(){
          this.localizacaoMapa();
      }

      localizacaoMapa = () => {
          try{
          fetch("http://192.168.4.221:5000/api/localizacoes")
          .then(resposta => resposta.json())
          .then(data => this.setState({ localizacoes: data }))
            }catch (error){
                console.log(error);
            }
        }

        
        

    render(){
        console.log(this.state.localizacoes)
        return(
            <div style={{ height: '100vh', width: '100%' }}>
                <GoogleMapReact
                defaultCenter={this.props.center}
                defaultZoom={this.props.zoom}
                >
                    {this.state.localizacoes.map(item => {
                        return (
                            <Local 
                                key={item.lancamento.nomr}
                                lat={item.latitude}
                                lng={item.longitude}
                                lancamento={item.lancamento}
                                />
                        )
                    })}


                </GoogleMapReact>
                
            </div>
            );
        }

    }//fim do mapa

export default Mapa;