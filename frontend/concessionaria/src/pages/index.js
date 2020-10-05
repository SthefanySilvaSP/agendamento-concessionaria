import React, { useState, useRef } from 'react';
import { useHistory } from "react-router-dom";

import './index.css';
import loginImg from '../storage/images/login.svg';
import LoadingBar from 'react-top-loading-bar';

import ConcessionariaAPI from '../services/ConcessionariaAPI';
const api = new ConcessionariaAPI();




export default function Login() {

    const navegacao = useHistory();
    const loadingBar = useRef(null);

    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");
    

    const login = async (e) => {
        
        e.preventDefault();
    
        loadingBar.current.continuousStart();

        const resp = await api.login({
            email: email,
            senha: senha
        });

        if(resp.perfil == "cliente"){
            navegacao.push("/c/menu", resp);
        } else {
            navegacao.push("/f/menu", resp);
        }

        
        loadingBar.current.complete();
        
        console.log(resp);
    };

    return (
        <div className="content_login">
            <LoadingBar 
                height={8}
                color='#135748'
                ref={loadingBar}
            />
   
            <div className="info_login">
                <h1>Faça Login em nossa Concessionária!</h1>
                <div className="fields_login">
                    <input type="text" 
                           placeholder="Digite seu email aqui."
                           className="form-control"
                           onChange={e => setEmail(e.target.value)} 
                    />
                    <input type="password" 
                           placeholder="Digite sua senha aqui."
                           className="form-control"
                           onChange={e => setSenha(e.target.value)} 
                    />
                </div>
                <button onClick={login} className="btn btn-outline-success">
                        Entrar
                </button>
            </div>

            <img src={loginImg} alt="Fazer login" />
        </div>
    )
}