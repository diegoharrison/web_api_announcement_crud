import axios from "axios";

const api_versoes = axios.create({
    baseURL: 'https://desafioonline.webmotors.com.br/api/OnlineChallenge/Version?ModelID=1'
});

export default api_versoes;