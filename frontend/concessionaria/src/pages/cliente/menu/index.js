import React, { useState } from 'react';
import { Link } from "react-router-dom";
import './index.css';

import Header from '../../../components/header';
import ParaAgendar from '../../../storage/images/time_management.svg';
import ParaConsultar from '../../../storage/images/server.svg';


export default function MenuCliente(props) {

    const [info, setInfo] = useState(props.location.state);


    return (
        <div className="menu_cliente_content">
            <Header />
            <div className="cabecalho">
                <h1> Olá, {props.location.state.nome}!</h1>
            </div>

            <div className="menu_opcoes">

                <Link to={{ pathname: "/c/agendar",
                            state: info         }}>
                    <div className="opcao">
                        <img src={ParaAgendar} alt="relógio" />
                        <h1> Agendar TestDrive </h1>
                    </div>
                </Link>

                <Link to={{ pathname: "/c/consultar",
                            state: info         }}>
                    <div className="opcao">
                        <img src={ParaConsultar} alt="server" />
                        <h1> Meus Agendamentos </h1>
                    </div>
                </Link>
            </div>
        </div>
    );
}