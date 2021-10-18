import React, { Component } from "react";
import api_marcas from './api_marcas'
import api_modelos from './api_modelos'
import api_versoes from './api_versoes'
import api_veiculos from "./api_veiculos";
class App extends Component {

  state = {
    marca: [],
    modelo: [],
    versao: [],
    veiculo:[]
  }

  async componentDidMount() {
    const response_marca = await api_marcas.get('')    
    const response_modelo = await api_modelos.get('')      
    const response_versao = await api_versoes.get('')
    const response_veiculo = await api_veiculos.get('')
    
    this.setState({ marca: response_marca.data, 
                    modelo: response_modelo.data,
                    versao: response_versao.data,
                    veiculo: response_veiculo.data
    });   
  }

  render() {

    const {marca} = this.state;
    const {modelo} = this.state;
    const {versao} = this.state;
    const {veiculo} = this.state;    
    
    return (
      <div>        
        {alert("Olá, tudo bem, peço desculpas por não ter terminado o projeto todo, mandando uma requisição do front para api, assim que 'startei' o projeto, apareceu uns contratempos no meu trabalho para resolver e fiquei até tarde, aí o tempo ficou limitado, mas nesse caso em relação ao front só pude mesmo fazer a chamada da api externa dos veículos, o que estava nos meus planos era fazer um sisteminha mesmo em react, fazendo consultas na api e realizando um cadastro escolhendo as informações da api requisitada, sobre o crud na api, os endpoints estão funcionando perfeitamente, caso queira testar via postman, desde já agradeço!")}
        <h1>Listar veículos (Marcas, Modelos e versões)</h1>
        <div></div>
        <div></div>
        <h2> # Marcas</h2>
        {marca.map(marca =>           
          <div key={marca}>
              <h3> - {marca.Name}</h3>
          </div>  
        )}

        <br></br>

        <h2># Modelos</h2>
        {modelo.map(modelo => 
          <div key={modelo}>
              <h3> - {modelo.Name}</h3>
          </div>  
        )}

        <br></br>

        <h2># Versões</h2>
        {versao.map(versao => 
          <div key={versao}>
              <h3> - {versao.Name}</h3>
          </div>  
        )}

        <br></br>

        {console.log(veiculo)};

        <h2># Veículos</h2>
        {veiculo.map(veiculo => 
          <div key={veiculo}>
              <h3> - {veiculo.ID} / {veiculo.Make} / {veiculo.Model} / {veiculo.vVersion} </h3>
          </div>  
        )}
      </div>
    );
  };
};

export default App;
