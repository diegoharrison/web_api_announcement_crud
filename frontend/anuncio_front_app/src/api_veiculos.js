import axios from "axios";

const api_veiculos = axios.create({
    baseURL: 'https://desafioonline.webmotors.com.br/api/OnlineChallenge/Vehicles?Page=1'
});

export default api_veiculos;