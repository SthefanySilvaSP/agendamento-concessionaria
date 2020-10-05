import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';

import Login from './pages';

import MenuCliente from './pages/cliente/menu';
import AgendarTestDriveCliente from './pages/cliente/agendar test-drive';
import ConsultarAgendamentosCliente from './pages/cliente/consultar agendamentos';

import MenuFuncionario from './pages/funcionario/menu';

export default function Routes() {
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/"       exact={true}  component={Login}                        />
                <Route path="/c/menu" exact={true}  component={MenuCliente}                  />
                <Route path="/c/agendar"            component={AgendarTestDriveCliente}      />
                <Route path="/c/consultar"          component={ConsultarAgendamentosCliente} />
                <Route path="/f/menu" exact={true}  component={MenuFuncionario}              />
            </Switch>
        </BrowserRouter>
    );
}