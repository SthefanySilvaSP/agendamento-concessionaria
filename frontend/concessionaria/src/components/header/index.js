import React from 'react';

import './index.css';
import iconeEmpresa from '../../storage/images/carros.svg';
import iconeNotificacao from '../../storage/images/sino de notificacao.png';
import imgUsuario from '../../storage/images/usuario.png';

export default function Header() {
    return (
        
        <div className="header_content">

            <div className="empresa_content">
                <img src={iconeEmpresa} alt="ícone da empresa" />
                <h4>Automóveis & Você</h4>
            </div>

            <div className="user_content">
                <img className="bell" src={iconeNotificacao} alt="ícone de notificações" />
                <img className="user" src={imgUsuario}       alt="imagem do usuário" />
            </div>

        </div>
    );
}