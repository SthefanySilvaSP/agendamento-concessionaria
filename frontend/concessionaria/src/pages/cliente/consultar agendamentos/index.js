import React, { useState, useRef, useEffect } from 'react';
import { Link } from "react-router-dom";
import './index.css';

import Header from '../../../components/header';
import LoadingBar from 'react-top-loading-bar';
import FeedbackImg from '../../../storage/images/rating.png';


import ConcessionariaAPI from '../../../services/ConcessionariaAPI';
const api = new ConcessionariaAPI();




export default function ConsultarAgendamentosCliente(props) {

    const [info, setInfo] = useState(props.location.state);
    const [agendamentos, setAgendamentos] = useState([]);

    const loadingBar = useRef(null);

    const consultar = async () => {

        loadingBar.current.continuousStart();

        const resp = await 
            api.consultarAgendamentos(props.location.state.loginID);
        setAgendamentos(resp);
        
        loadingBar.current.complete();
    }

    useEffect(() => {
        consultar();
      }, []);



    return (
        <div className="consultar_agendamentos_content">

            <Header />

            <LoadingBar 
                height={8}
                color='#135748'
                ref={loadingBar}
            />

            <h1>{props.location.state.nome}, esses são seus agendamentos</h1>

            <div id="table_box">
                <table className="table table-hover">
                    <thead className="">
                        <tr>
                            <th>Carro</th>
                            <th>Funcionário</th>
                            <th>Data</th>
                            <th>Status</th>
                            <th>Dê seu feedback</th>
                        </tr>
                    </thead>

                    <tbody>
                        {agendamentos.map(item => 
                            <tr key={item.id}>
                                <th>{item.carro}</th>
                                <td>{item.funcionario}</td>
                                <td> { new Date(item.data + "Z").toLocaleDateString() }</td>
                                <td>{item.situacao}</td>
                                <td>
                                    <Link to={{
                                        pathname: "",
                                        state: info
                                    }} className="btn btn-outline-secondary">
                                            <img src={FeedbackImg} alt="dando feedback" />
                                    </Link>
                                </td>
                            </tr>)}
                    </tbody>
                </table>
            </div>

        </div>
    );
}