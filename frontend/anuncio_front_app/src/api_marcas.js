import axios from "axios";

const api_marcas = axios.create({
    baseURL: 'https://desafioonline.webmotors.com.br/api/OnlineChallenge/Make'
});

export default api_marcas;