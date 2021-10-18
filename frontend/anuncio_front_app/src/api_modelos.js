import axios from "axios";

const api_modelos = axios.create({
    baseURL: 'https://desafioonline.webmotors.com.br/api/OnlineChallenge/Model?MakeID=1'
});

export default api_modelos;