import axios from 'axios';

const api = axios.create({
    baseURL: 'http://localhost:5000/agendamento'
})

export default class ConcessionariaAPI {

    async login(req) {
        const resp = await api.post('/login', req);
        return resp.data;
    }

    async consultarCarros() {
        const resp = await api.get('/carros');
        return resp.data;
    }

    async agendarTestDrive(req) {
        const resp = await api.post('/agendar', req);
        return resp.data;
    }

    async consultarAgendamentos(id) {
        const resp = await api.get(`/agendamentos/${id}`);
        return resp.data;
    }
}