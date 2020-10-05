import React, { useState, useEffect, useRef } from 'react';
import './index.css';

import Header from '../../../components/header';
import LoadingBar from 'react-top-loading-bar';

import ConcessionariaAPI from '../../../services/ConcessionariaAPI';
const api = new ConcessionariaAPI();



export default function AgendarTestDriveCliente(props) {

    const loadingBar = useRef(null);
    const [info, setInfo] = useState(props.location.state);
    const [carros, setCarros] = useState([]);

    const [idCarro, setIdCarro] = useState();
    const [data, setData] = useState("");

    const consultarCarros = async () => {
        const resp = await api.consultarCarros();
        setCarros(resp);
    };

    const agendarTestDrive = async () => {

        loadingBar.current.continuousStart();
        
        console.log(info.LoginID);
        console.log(idCarro);
        console.log(data);
        
        const resp = await api.agendarTestDrive({
            idLogin: info.LoginID,
            idCarro: idCarro,
            data: data
        });

        loadingBar.current.complete();
    }

    useEffect(() => {
    consultarCarros();
    }, []);

    return (
        <div className="testdrive_content">
            <Header />

            <LoadingBar 
                height={8}
                color='#135748'
                ref={loadingBar}
            />

            <div className="testdrive_card">
                <div className="instrucoes">
                    <h3>O agendamento será feito no nome de {props.location.state.nome}. Preencha abaixo para concluir.</h3>
                </div>
                <div className="informacoes">
                    <div>
                        <h5>Selecione a data: </h5>
                        <input type="date" onChange={e => setData(e.target.value)} />
                    </div>
                    <select name="carros" id="carros" onChange={(e) => setIdCarro(e.target.value)}>
                        <option value={0}>Escolha um carro</option>
                        {carros.map(item =>
                            <option value={item.id}>{item.nome}</option>
                        )};
                    </select>
                </div>
                <button onClick={agendarTestDrive}>Fazer Agendameto</button>
            </div>

        </div>
    );
}