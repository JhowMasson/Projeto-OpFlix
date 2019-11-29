import React from 'react';

import {Link} from 'react-router-dom';
import logo from '../../assets/img/imagem-opflix.png';


function Rodape(){
    return(
        <footer className="rodape">


            <div className="img-rodape">
                <Link to="/"> <img id="rodape-img" src={logo} /> </Link>
                </div>
            <div className="rodape-contato">
                <p id= "contatos">
                    (11) 1234-54321
                <br/>
                    contatoopflix@email.com
                </p>
            </div>
        </footer>
    );
}
export default Rodape;

